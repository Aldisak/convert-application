using ConvertApp.Storage.Implementation;

namespace ConvertApp.Storage;

public class StorageStrategy
{
    private readonly IStorageStrategy _sourceStorageStrategy;
    private readonly IStorageStrategy _targetStorageStrategy;

    public StorageStrategy(
        string sourceStorageType,
        string targetStorageType)
    {
        _sourceStorageStrategy = SelectStrategy(sourceStorageType);
        _targetStorageStrategy = SelectStrategy(targetStorageType);
    }

    public Task<string> Load(string sourcePath) => _sourceStorageStrategy.Load(sourcePath);
    public Task Save(string path, string content) => _targetStorageStrategy.Save(path, content);

    private static IStorageStrategy SelectStrategy(string storageType)
    {
        if (storageType.StartsWith("http"))
            return new HttpStorage();
        return new FileStorage();
    }
}