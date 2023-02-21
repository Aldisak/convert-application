using Newtonsoft.Json;

namespace ConvertApp.Converter.Implementation;

internal class DocumentJson : IDocumentConverterStrategy
{
    public Document ConvertFrom(string input) => JsonConvert.DeserializeObject<Document>(input)!;

    public string ConvertTo(Document input) => JsonConvert.SerializeObject(input);
}