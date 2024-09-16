using Microsoft.EntityFrameworkCore;
using StorageMicroservice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMicroservice.Infrastructure.Data
{
    public class StorageDbContext : DbContext
    {
        public StorageDbContext(DbContextOptions<StorageDbContext> options)
            : base(options)
        {
        }

        public DbSet<FileMetadata> FileMetadata { get; set; }
    }
}
