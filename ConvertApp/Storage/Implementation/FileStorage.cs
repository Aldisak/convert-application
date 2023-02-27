namespace ConvertApp.Storage.Implementation;

internal class FileStorage : IStorageStrategy
{
    public Task<string> Load(Uri sourcePath)
    {
        return File.ReadAllTextAsync(sourcePath.LocalPath);
    }

    public Task Save(Uri path, string content)
    {
        return File.WriteAllTextAsync(path.LocalPath, content);
    }
}