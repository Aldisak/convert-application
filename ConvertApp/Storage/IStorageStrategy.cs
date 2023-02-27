namespace ConvertApp.Storage;

public interface IStorageStrategy
{
    public Task<string> Load(Uri sourcePath);
    public Task Save(Uri path, string content);
}