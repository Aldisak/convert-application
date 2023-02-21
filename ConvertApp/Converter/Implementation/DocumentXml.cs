using System.Xml.Linq;

namespace ConvertApp.Converter.Implementation;

internal class DocumentXml : IDocumentConverterStrategy
{
    public Document ConvertFrom(string input)
    {
        var xDoc = XDocument.Parse(input);
        var elements = xDoc.Root?.Elements().ToList();

        // Validate XML
        if (elements == null) throw new Exception("Invalid XML. Document element is missing or invalid.");
        if (elements.Find(el => el.Name.LocalName == "Title") == null) throw new Exception("Invalid XML. Title element is missing or invalid.");
        if (elements.Find(el => el.Name.LocalName == "Text") == null) throw new Exception("Invalid XML. Title element is missing or invalid.");

        var document = new Document
        {
            Title = elements.Find(el => el.Name.LocalName == "Title")!.Value,
            Text = elements.Find(el => el.Name.LocalName == "Text")!.Value
        };
        return document;
    }
    
    public string ConvertTo(Document input)
    {
        var xDoc = new XDocument(
            new XElement("Root",
                new XElement("Title", input.Title),
                new XElement("Text", input.Text)
            )
        );
        return xDoc.ToString();
    }
}