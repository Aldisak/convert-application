namespace ConvertApp.Storage.Implementation;

internal class FileStorage : IStorageStrategy
{
    public Task<string> Load(string sourcePath)
    {
        return File.ReadAllTextAsync(sourcePath);
    }

    public Task Save(string path, string content)
    {
        if (Directory.Exists(Path.GetDirectoryName(path)) == false)
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);

        return File.WriteAllTextAsync(path, content);
    }
}