using Microsoft.AspNetCore.Http;

namespace ECommercenet6.Application.Abstractions.Storage;

public interface IStorage
{
    Task<List<(string filename, string pathOrContainerName)>> UploadAsync(string pathOrContainerName,IFormFileCollection files);
    Task DeleteAsync(string pathOrContainerName,string fileName);
    List<string> GetFiles(string pathOrContainerName);
    bool HasFile(string path, string fileName);

}