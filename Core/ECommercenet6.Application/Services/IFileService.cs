using Microsoft.AspNetCore.Http;

namespace ECommercenet6.Application.Services;

public interface IFileService
{
    //Task<List<(string fileName,string path)>> UploadAsync(string path,IFormFileCollection files);
    Task<bool> CopyFileAsync(string path,IFormFile file);
    

}