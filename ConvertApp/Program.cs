using ConvertApp.Converter;

namespace ConvertApp
{
    class Program
    {
        static void Main(string[] args)
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

            try
            {
                var converter = new DocumentConverterStrategy(sourceFileName, targetFileName);

                var document = converter.ConvertFrom(File.ReadAllText(sourceFileName)) ??
                               throw new Exception("Invalid input file.");

                File.WriteAllText(targetFileName, converter.ConvertTo(document));

                Console.WriteLine("Conversion completed.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}