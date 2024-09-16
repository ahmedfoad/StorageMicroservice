using Microsoft.AspNetCore.Http;
using StorageMicroservice.Domain.Models;
using StorageMicroservice.Infrastructure.Repositories;

namespace StorageMicroservice.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task UploadFileAsync(IFormFile file)
        {
            var filePath = Path.Combine("Storage", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

         
            var fileMetadata = new FileMetadata
            {
                FileId = Guid.NewGuid().ToString(), 
                FileName = file.FileName,
                ContentType = file.ContentType,
                Size = file.Length,
                UploadedAt = DateTime.UtcNow
            };

            // Save file metadata to the database
            await _fileRepository.SaveFileAsync(fileMetadata);
        }

        public async Task<byte[]> DownloadFileAsync(string fileId)
        {
            // Retrieve the file from the pysical storage
            var filePath = Path.Combine("Storage", fileId);
            return await File.ReadAllBytesAsync(filePath);
        }
    }
}
