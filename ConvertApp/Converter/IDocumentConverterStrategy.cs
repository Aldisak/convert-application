namespace ConvertApp.Converter;

internal interface IDocumentConverterStrategy
{
    Document ConvertFrom(string input);
    string ConvertTo(Document input);
}