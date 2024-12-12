using DemoAspose.InputOutput.StreamProvider;

namespace DemoAspose.InputOutput.Tests.StreamProvider;
public class StreamProviderTests : IDisposable
{
    private readonly IStreamProvider StreamProvider;
    private readonly string tempInputFilePath;
    private readonly string tempOutputFilePath;

    public StreamProviderTests()
    {
        StreamProvider = new InputOutput.StreamProvider.StreamProvider();
        tempInputFilePath = Path.GetTempFileName();
        tempOutputFilePath = Path.GetTempFileName();

        File.WriteAllText(tempInputFilePath, "Test data for input stream.");

    }

    [Fact]
    public void CreateInputStream_ValidFileName_ReturnsFileStream()
    {
        // Arrange

        // Act
        var result = StreamProvider.CreateInputStream(tempInputFilePath);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<FileStream>(result);

        Assert.True(result.CanRead);
        Assert.False(result.CanWrite);
        Assert.True(result.CanSeek);

        result.Dispose();
    }

    [Fact]
    public void CreateOutputStream_ValidFileName_ReturnsFileStream()
    {
        // Arrange

        // Act
        var result = StreamProvider.CreateOutputStream(tempOutputFilePath);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<FileStream>(result);

        Assert.True(result.CanRead);
        Assert.True(result.CanWrite);
        Assert.True(result.CanSeek);

        result.Dispose();
    }

    [Fact]
    public void CreateInputStream_FileDoesNotExist_ShouldThrowFileNotFoundException()
    {
        // Arrange
        var nonExistentFilePath = Path.Combine(Path.GetTempPath(), "nonexistentfile.txt");

        // Act & Assert
        var exception = Assert.Throws<FileNotFoundException>(() => StreamProvider.CreateInputStream(nonExistentFilePath));
        Assert.Contains(nonExistentFilePath, exception.Message);
    }

    public void Dispose()
    {
        if (File.Exists(tempInputFilePath))
        {
            File.Delete(tempInputFilePath);
        }

        if (File.Exists(tempOutputFilePath))
        {
            File.Delete(tempOutputFilePath);
        }
    }

}