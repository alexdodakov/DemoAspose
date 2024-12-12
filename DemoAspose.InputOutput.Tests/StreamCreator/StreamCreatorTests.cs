using DemoAspose.StreamCreator;

namespace DemoAspose.InputOutput.Tests.StreamCreator;
public class StreamCreatorTests : IDisposable
{
    private readonly IStreamCreator streamCreator;
    private readonly string tempInputFilePath;
    private readonly string tempOutputFilePath;

    public StreamCreatorTests()
    {
        streamCreator = new DemoAspose.StreamCreator.StreamCreator();
        tempInputFilePath = Path.GetTempFileName();
        tempOutputFilePath = Path.GetTempFileName();

        File.WriteAllText(tempInputFilePath, "Test data for input stream.");

    }

    [Fact]
    public void CreateInputStream_ValidFileName_ReturnsFileStream()
    {
        // Arrange

        // Act
        var result = streamCreator.CreateInputStream(tempInputFilePath);

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
        var result = streamCreator.CreateOutputStream(tempOutputFilePath);

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
        var exception = Assert.Throws<FileNotFoundException>(() => streamCreator.CreateInputStream(nonExistentFilePath));
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