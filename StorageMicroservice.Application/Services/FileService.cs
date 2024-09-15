using Microsoft.AspNetCore.Http;

namespace StorageMicroservice.Application.Services
{
    public class FileService : IFileService
    {
        public async Task UploadFileAsync(IFormFile file)
        {
            // Save the file to storage
            var filePath = Path.Combine("Storage", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        public async Task<byte[]> DownloadFileAsync(string fileId)
        {
            // Retrieve the file from storage
            var filePath = Path.Combine("Storage", fileId);
            return await File.ReadAllBytesAsync(filePath);
        }
    }
}
