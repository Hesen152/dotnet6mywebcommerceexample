using ECommercenet6.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace ECommercenet6.Infrastructure.Services.Storage;

public class StorageService:IStorageService

{
    private readonly IStorage _storage;

    public StorageService(IStorage storage)
    {
        _storage = storage;
    }


    public Task<List<(string filename, string pathOrContainerName)>> UploadAsync(string pathOrContainerName,
        IFormFileCollection files)
        => _storage.UploadAsync(pathOrContainerName, files);   
    public async  Task DeleteAsync(string pathOrContainerName, string fileName)
        => await  _storage.DeleteAsync(pathOrContainerName, fileName);

    public List<string> GetFiles(string pathOrContainerName)
        => _storage.GetFiles(pathOrContainerName);

    public bool HasFile(string path, string fileName)
        => _storage.HasFile(path, fileName);

    public string StorageName
    {
        get => _storage.GetType().Name;
    }
}