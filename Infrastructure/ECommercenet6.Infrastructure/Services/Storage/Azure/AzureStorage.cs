using System.ComponentModel;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ECommercenet6.Application.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;

namespace ECommercenet6.Infrastructure.Services.Storage.Azure;

public class AzureStorage:Storage,IAzureStorage
{

    readonly BlobServiceClient _blobServiceClient;
     BlobContainerClient _blobContainerClient;

    public AzureStorage(IConfiguration configuration)
    {
        _blobServiceClient = new BlobServiceClient(configuration["Storage:Azure"]);
    }
 public async  Task<List<(string filename, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        await _blobContainerClient.CreateIfNotExistsAsync();
        await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
        List<(string filename, string pathOrContainerName)> datas = new();
        foreach (IFormFile file in files)
        {
          string filenewName=await   FileRenameAsync(containerName, file.Name, HasFile);
         
         BlobClient blobClient= _blobContainerClient.GetBlobClient(filenewName);
         await blobClient.UploadAsync(file.OpenReadStream());
         datas.Add((filenewName, $"{containerName}/{filenewName}"));
        }

        return datas;
    }

    public async Task DeleteAsync(string containerName, string fileName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
        await blobClient.DeleteAsync();
    }

    public List<string> GetFiles(string containerName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        return _blobContainerClient.GetBlobs().Select(t => t.Name).ToList();

    }

    public bool HasFile(string containerName, string fileName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        return _blobContainerClient.GetBlobs().Any(c => c.Name == fileName);
    }
}