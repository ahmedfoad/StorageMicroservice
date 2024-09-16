using Microsoft.EntityFrameworkCore;
using StorageMicroservice.Domain.Models;
using StorageMicroservice.Infrastructure.Data;

namespace StorageMicroservice.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly StorageDbContext _context;

        public FileRepository(StorageDbContext context)
        {
            _context = context;
        }

        public async Task SaveFileAsync(FileMetadata file)
        {
            _context.FileMetadata.Add(file);
            await _context.SaveChangesAsync();
        }

        public async Task<FileMetadata> GetFileMetadataAsync(string fileId)
        {
            return await _context.FileMetadata.FirstOrDefaultAsync(f => f.FileId == fileId);
        }
    }
}
