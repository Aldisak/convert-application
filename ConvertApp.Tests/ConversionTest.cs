using ConvertApp.Converter;
using ConvertApp.Storage;

namespace ConvertApp.Tests;

public class ConversionTest
{
    [SetUp]
    public void Setup()
    {
        File.WriteAllText("source.xml", "<Root><Title>Test title</Title><Text>Test text</Text></Root>");
        File.WriteAllText("source.json", "{\"Title\":\"Test title\",\"Text\":\"Test text\"}");
    }

    [Test]
    public static async Task ConversionFromXmlToJson()
    {
        const string sourceFilePath = "source.json";
        const string targetFilePath = "target.xml";
        const string expect = "<Root><Title>Test title</Title><Text>Test text</Text></Root>";

        var storage = new StorageStrategy(sourceFilePath, targetFilePath);
        var converter = new DocumentConverterStrategy(sourceFilePath, targetFilePath);

        var document = converter.ConvertFrom(await storage.Load(sourceFilePath));
        var result = converter.ConvertTo(document)
            .Replace("\r", "")
            .Replace("\n", "")
            .Replace("  ", "");

        Assert.AreEqual(expect, result);
    }

    [Test]
    public static async Task ConversionFromJsonToXml()
    {
        const string sourceFilePath = "source.xml";
        const string targetFilePath = "target.json";
        const string expect = "{\"Title\":\"Test title\",\"Text\":\"Test text\"}";

        var storage = new StorageStrategy(sourceFilePath, targetFilePath);
        var converter = new DocumentConverterStrategy(sourceFilePath, targetFilePath);

        var document = converter.ConvertFrom(await storage.Load(sourceFilePath));
        var result = converter.ConvertTo(document);

        Assert.AreEqual(expect, result);
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete("source.json");
        File.Delete("source.xml");
        File.Delete("target.json");
        File.Delete("target.xml");
    }
}