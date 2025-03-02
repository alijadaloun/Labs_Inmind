using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Lab1.Services.UniversityServices;

public class BlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string _container;

    public BlobStorageService(IConfiguration configuration)
    {
        _blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("StorageAccount"));
        _container = configuration["AzureBlobStorage:ContainerName"];
        
        
    }


    public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_container);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
        
        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(fileStream, true);

        return blobClient.Uri.ToString();
    }

    public async Task<bool> DeleteFileAsync(string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_container);
        var blobClient = containerClient.GetBlobClient(fileName);
        return await blobClient.DeleteIfExistsAsync();
    }
    
    
}