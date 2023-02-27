namespace ConvertApp.Storage.Implementation;

internal class HttpStorage : IStorageStrategy
{
    private static readonly HttpClient Client = new();

    public async Task<string> Load(string sourcePath)
    {
        var response = await Client.GetAsync(sourcePath);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task Save(string path, string content)
    {
        await Client.PostAsync(path, new StringContent(content));
    }
}