using ECommercenet6.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ECommercenet6.Infrastructure.Services.Storage.Local;

public class LocalStorage:Storage,ILocalStorage
{
    
    private readonly IWebHostEnvironment _webHostEnvironment;

    public LocalStorage(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    
    
     async Task<bool> CopyFileAsync(string path, IFormFile file)
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
    
    
    
    
    public async Task<List<(string filename, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
    {
        string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);
        List<(string fileName, string path)> datas = new();
        

        foreach (IFormFile file in files)
        {
            
            string filenewName=await   FileRenameAsync(path, file.Name, HasFile);
            
           await CopyFileAsync($"{uploadPath}\\{filenewName}", file);
            datas.Add((filenewName,$"{path}\\{filenewName}"));
        }

        return datas;
        
        
    }

    public async  Task DeleteAsync(string path, string fileName)=>
    File.Delete($"{path}\\{fileName}");

    public List<string> GetFiles(string pathOrContainerName)
    {
        throw new NotImplementedException();
    }


    public List<string> GetFiles(string path, string fileName)
    {
        DirectoryInfo directoryInfo = new(path);
        return directoryInfo.GetFiles().Select(f => f.Name).ToList();
    }

    public bool HasFile(string path, string fileName)=>
    File.Exists($"{path}\\{fileName}");

}