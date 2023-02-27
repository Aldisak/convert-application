using ConvertApp.Converter;
using ConvertApp.Storage;

namespace ConvertApp
{
    class Program
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

            var sourceFileName = Path.Combine(Environment.CurrentDirectory, args[0]);
            var targetFileName = Path.Combine(Environment.CurrentDirectory, args[1]);

            var sourceFilePath = new Uri(args[0]);
            var targetFilePath = new Uri(args[1]);

            try
            {
                var storage = new StorageStrategy(sourceFilePath, targetFilePath);
                var converter = new DocumentConverterStrategy(sourceFileName, targetFileName);

                var document = converter.ConvertFrom(await storage.Load(sourceFilePath));
                    
                await storage.Save(targetFilePath, converter.ConvertTo(document));

                Console.WriteLine("Conversion completed.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}