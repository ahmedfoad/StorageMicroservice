using Microsoft.AspNetCore.Mvc;
using StorageMicroservice.Application.Services;

namespace StorageMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        // Injecting IFileService via the constructor
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file provided.");

           await _fileService.UploadFileAsync(file);

            return Ok("File uploaded successfully.");
        }

        [HttpGet("download/{fileId}")]
        public async Task<IActionResult> DownloadFile(string fileId)
        {
            var filePath = Path.Combine("Storage", fileId);

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found.");

            var fileBytes = await _fileService.DownloadFileAsync(fileId);

            if (fileBytes == null || fileBytes.Length == 0)
                return NotFound("File not found.");

            var contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileId);
        }
    }
}
