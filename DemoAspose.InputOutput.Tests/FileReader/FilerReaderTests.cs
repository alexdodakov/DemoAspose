using System.Text;

namespace DemoAspose.InputOutput.Tests.FileReader;

public class FileReaderTests
{
    private readonly InputOutput.FileReader.IFileReader _fileReader;

    public FileReaderTests()
    {
        _fileReader = new InputOutput.FileReader.FileReader();
    }

    [Fact]
    public async Task ReadLinesAsync_ValidInput_ReturnsExpectedLines()
    {
        // Arrange
        var input = "3\nLine 1\nLine 2\nLine 3\nLine 4\n";
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));

        // Act
        var lines = await _fileReader.ReadLinesAsync(stream).ToListAsync();

        // Assert
        Assert.Equal(new[] { "Line 1", "Line 2", "Line 3", "Line 4" }, lines);
    }

    [Fact]
    public async Task ReadLinesAsync_ZeroLineNumber_ReturnsNoLines()
    {
        // Arrange
        var input = "0\nLine 1\nLine 2\nLine 3\n";
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));

        // Act
        var lines = await _fileReader.ReadLinesAsync(stream).ToListAsync();

        // Assert
        Assert.Empty(lines);
    }

    [Fact]
    public async Task ReadLinesAsync_NegativeLineNumber_ThrowsArgumentException()
    {
        // Arrange
        var input = "-1\nLine 1\nLine 2\nLine 3\n";
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));


        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await _fileReader.ReadLinesAsync(stream).ToListAsync());
    }

    [Fact]
    public async Task ReadLinesAsync_LineNumberTooHigh_ThrowsArgumentException()
    {
        // Arrange
        var input = "101\nLine 1\nLine 2\nLine 3\n";
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await _fileReader.ReadLinesAsync(stream).ToListAsync());
    }

    [Fact]
    public async Task ReadLinesAsync_EmptyStream_ThrowsArgumentException()
    {
        // Arrange
        using var stream = new MemoryStream();

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await _fileReader.ReadLinesAsync(stream).ToListAsync());
    }

    [Fact]
    public async Task ReadLinesAsync_NonIntegerLineNumber_ThrowsArgumentException()
    {
        // Arrange
        var input = "abc\nLine 1\nLine 2\nLine 3\n";
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await _fileReader.ReadLinesAsync(stream).ToListAsync());
    }
}