using Microsoft.AspNetCore.Http;

namespace StorageMicroservice.Application.Services;

public interface IFileService
{
    Task UploadFileAsync(IFormFile file);
    Task<byte[]> DownloadFileAsync(string fileId);
}
