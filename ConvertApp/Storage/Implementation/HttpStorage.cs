namespace ConvertApp.Storage.Implementation;

internal class HttpStorage : IStorageStrategy
{
    private static readonly HttpClient Client = new();

    public async Task<string> Load(Uri sourcePath)
    {
        var response = await Client.GetAsync(sourcePath);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task Save(Uri path, string content)
    {
        await Client.PostAsync(path, new StringContent(content));
    }
}