using StorageMicroservice.Domain.Models;

namespace StorageMicroservice.Infrastructure.Repositories;

public interface IFileRepository
{
    Task SaveFileAsync(FileMetadata file);
    Task<FileMetadata> GetFileMetadataAsync(string fileId);
}
