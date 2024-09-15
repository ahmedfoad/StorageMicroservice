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
            // Check if a file was provided
            if (file == null || file.Length == 0)
                return BadRequest("No file provided.");

            // Call the application service to handle the file upload
            await _fileService.UploadFileAsync(file);

            return Ok("File uploaded successfully.");
        }

        [HttpGet("download/{fileId}")]
        public async Task<IActionResult> DownloadFile(string fileId)
        {
            var filePath = Path.Combine("Storage", fileId);

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found.");

            // Retrieve the file from the service
            var fileBytes = await _fileService.DownloadFileAsync(fileId);

            if (fileBytes == null || fileBytes.Length == 0)
                return NotFound("File not found.");

            // Set a generic content type for all file extensions
            var contentType = "application/octet-stream";

            // Return the file as a FileResult
            return File(fileBytes, contentType, fileId);
        }
    }
}
