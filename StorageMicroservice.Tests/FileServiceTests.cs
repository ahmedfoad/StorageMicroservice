using Moq;
using StorageMicroservice.Application.Services;

namespace StorageMicroservice.Tests;

public class FileServiceTests
{
    private readonly Mock<IFileService> _fileServiceMock;

    public FileServiceTests()
    {
        _fileServiceMock = new Mock<IFileService>();
    }

    [Fact]
    public async Task UploadFile_ShouldSucceed()
    {
        // Arrange
        var fileService = _fileServiceMock.Object;

        // Act
        await fileService.UploadFileAsync(null);

        // Assert
        _fileServiceMock.Verify(s => s.UploadFileAsync(null), Times.Once);
    }
}
