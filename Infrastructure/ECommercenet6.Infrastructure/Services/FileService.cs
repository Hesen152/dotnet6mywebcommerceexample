using System.Diagnostics;
using ECommercenet6.Application.Services;
using ECommercenet6.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Constraints;

namespace ECommercenet6.Infrastructure.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    // public async Task<List<(string fileName,string path)>> UploadAsync(string path, IFormFileCollection files)
    // {
    //     string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
    //
    //     if (!Directory.Exists(uploadPath))
    //         Directory.CreateDirectory(uploadPath);
    //     List<(string fileName, string path)> datas = new();
    //     
    //     List<bool> results = new();
    //
    //     foreach (IFormFile file in files)
    //     {
    //         
    //        bool result=await CopyFileAsync($"{uploadPath}\\{filenewName}", file);
    //        datas.Add((filenewName,$"{path}\\{filenewName}"));
    //        results.Add(result);
    //     }
    //
    //     if (results.TrueForAll(r=>r.Equals(true)))
    //     {return datas;}
    //     
    //     
    //     //todos we must throwing excepton when file uploading in server exception
    //     else
    //     {
    //         return null;
    //     }
    //         
    //
    //     
    //     
    //
    // }

    
    public async Task<bool> CopyFileAsync(string path, IFormFile file)
    {
        try
        {
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write,
                FileShare.None, 1024 * 1024,
                useAsync: false);

            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            return true;
        }

       
        
        
        catch (Exception ex)
        {
            //todo log 
            throw ex;
        }
    }
}