namespace ConvertApp.Storage;

public interface IStorageStrategy
{
    public Task<string> Load(string sourcePath);
    public Task Save(string path, string content);
}