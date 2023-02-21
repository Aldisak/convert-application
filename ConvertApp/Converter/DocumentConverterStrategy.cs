using ConvertApp.Converter.Implementation;

namespace ConvertApp.Converter;

internal class DocumentConverterStrategy
{
    private IDocumentConverterStrategy _convertFromStrategy;
    private IDocumentConverterStrategy _convertToStrategy;

    public DocumentConverterStrategy(
        string sourceFileName,
        string targetFileName)
    {
        var sourceExtension = Path.GetExtension(sourceFileName);
        var targetExtension = Path.GetExtension(targetFileName);

        _convertFromStrategy = SelectStrategy(sourceExtension, "Source file format is not supported.");
        _convertToStrategy = SelectStrategy(targetExtension, "Target file format is not supported.");
    }

    public Document ConvertFrom(string input) => _convertFromStrategy.ConvertFrom(input);

    public string ConvertTo(Document input) => _convertToStrategy.ConvertTo(input);

    private static IDocumentConverterStrategy SelectStrategy(string target, string errorMessage)
        =>
            target switch
            {
                ".json" => new DocumentJson(),
                ".xml" => new DocumentXml(),
                _ => throw new Exception(errorMessage)
            };
}