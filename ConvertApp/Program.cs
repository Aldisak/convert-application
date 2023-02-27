using ConvertApp.Converter;
using ConvertApp.Storage;

namespace ConvertApp;

public static class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length <= 1)
        {
            if (args.Length == 1 && (args[0].StartsWith("-h") || args[0].StartsWith("--h")))
                Console.WriteLine("ConvertApp.exe <source file> <target file>");
            else
                Console.WriteLine("Invalid arguments. Use -h or --h for help.");
            return;
        }

        try
        {
            await ProcessConvert(args[0], args[1]);

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private static async Task ProcessConvert(string sourceFilePath, string targetFilePath)
    {
        var storage = new StorageStrategy(sourceFilePath, targetFilePath);
        var converter = new DocumentConverterStrategy(sourceFilePath, targetFilePath);

        var document = converter.ConvertFrom(await storage.Load(sourceFilePath));

        await storage.Save(targetFilePath, converter.ConvertTo(document));
    }
}