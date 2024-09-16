using System.ComponentModel.DataAnnotations;

namespace StorageMicroservice.Domain.Models;

public class FileMetadata
{
    [Key]
    public int Id { get; set; }
    public string FileId { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public long Size { get; set; }
    public DateTime UploadedAt { get; set; }
}
