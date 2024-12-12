using DemoAspose.InputOutput.FileWriter;

namespace DemoAspose.InputOutput.Tests.FileWriter;
public class FileWriterTests : IDisposable
{
    private readonly IFileWriter _fileWriter;
    private readonly string _tempFilePath;

    public FileWriterTests()
    {
        _fileWriter = new InputOutput.FileWriter.FileWriter();
        _tempFilePath = Path.GetTempFileName();
    }

    [Fact]
    public async Task WriteLinesAsync_ThreeLinesProvided_ShouldWriteLinesToFile()
    {
        // Arrange
        var lines = new List<string> { "Line 1", "Line 2", "Line 3" };

        // Act
        using (var fileStream = new FileStream(_tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            await _fileWriter.WriteLinesAsync(fileStream, lines);
        }

        // Assert
        var result = await File.ReadAllTextAsync(_tempFilePath);
        var expectedOutput = string.Join(Environment.NewLine, lines);
        Assert.Equal(expectedOutput, result);
    }

    [Fact]
    public async Task WriteLinesAsync_ZeroLinesProvided_ShouldHandleEmptyLines()
    {
        // Arrange
        var lines = new List<string>();

        // Act
        using (var fileStream = new FileStream(_tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            await _fileWriter.WriteLinesAsync(fileStream, lines);
        }

        // Assert
        var result = await File.ReadAllTextAsync(_tempFilePath);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task WriteLinesAsync_LinesArrayIsNull_ShouldHandleNullLine()
    {
        // Arrange
        List<string> lines = null;

        // Act
        using (var fileStream = new FileStream(_tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            await _fileWriter.WriteLinesAsync(fileStream, lines);
        }

        // Assert
        var result = await File.ReadAllTextAsync(_tempFilePath);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task WriteLinesAsync_SingleLineProvided_ShouldHandleSingleLine()
    {
        // Arrange
        var lines = new List<string> { "Single Line" };

        // Act
        using (var fileStream = new FileStream(_tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            await _fileWriter.WriteLinesAsync(fileStream, lines);
        }

        // Assert
        var result = await File.ReadAllTextAsync(_tempFilePath);
        var expectedOutput = "Single Line";
        Assert.Equal(expectedOutput, result);
    }

    [Fact]
    public async Task WriteLinesAsync_NullStreamProvided_ShouldHandleNullLines()
    {
        // Arrange
        var lines = new List<string> { "Single Line" };
        FileStream fileStream = null;
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _fileWriter.WriteLinesAsync(fileStream, lines));
    }

    public void Dispose()
    {
        if (File.Exists(_tempFilePath))
        {
            File.Delete(_tempFilePath);
        }
    }
}