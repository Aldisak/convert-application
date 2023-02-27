using ConvertApp.Storage.Implementation;

namespace ConvertApp.Storage;

internal class StorageStrategy
{
    private readonly IStorageStrategy _sourceStorageStrategy;
    private readonly IStorageStrategy _targetStorageStrategy;

    public StorageStrategy(
        Uri sourcePath,
        Uri targetPath)
    {
        _sourceStorageStrategy = SelectStrategy(sourcePath, "Source storage is not supported.");
        _targetStorageStrategy = SelectStrategy(targetPath, "Target storage is not supported.");
    }

    public Task<string> Load(Uri sourcePath) => _sourceStorageStrategy.Load(sourcePath);
    public Task Save(Uri path, string content) => _targetStorageStrategy.Save(path, content);

    private static IStorageStrategy SelectStrategy(Uri uri, string errorMessage)
        =>
            uri.Scheme switch
            {
                "file" => new FileStorage(),
                "http" => new HttpStorage(),
                "https" => new HttpStorage(),
                _ => throw new Exception(errorMessage)
            };
}