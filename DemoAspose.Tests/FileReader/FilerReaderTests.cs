//using DemoAspose.FileReader;
//using System.Text;

//namespace DemoAspose.Tests.FileReader;

//public class StreamReaderTests
//{
//    private readonly IFileReader fileReader;
//    public StreamReaderTests()
//    {
//        fileReader = new DemoAspose.FileReader.FileReader();
//    }

//    [Fact]
//    public async Task ReadLinesAsync_WithMultipleLines_ReturnsAllLines()
//    {
//        // Arrange
//        var input = "Line 1\nLine 2\nLine 3";
//        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
//        var expectedLines = new List<string> { "Line 1", "Line 2", "Line 3" };

//        // Act
//        var lines = new List<string>();
//        await foreach (var line in fileReader.ReadLinesAsync(stream))
//        {
//            lines.Add(line);
//        }

//        // Assert
//        Assert.Equal(expectedLines, lines);
//    }

//    [Fact]
//    public async Task ReadLinesAsync_WithEmptyStream_ReturnsNoLines()
//    {
//        // Arrange
//        using var stream = new MemoryStream();

//        // Act
//        var lines = new List<string>();
//        await foreach (var line in fileReader.ReadLinesAsync(stream))
//        {
//            lines.Add(line);
//        }

//        // Assert
//        Assert.Empty(lines);
//    }

//    [Fact]
//    public async Task ReadLinesAsync_WithSingleLine_ReturnsSingleLine()
//    {
//        // Arrange
//        var input = "Single Line";
//        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
//        var expectedLines = new List<string> { "Single Line" };

//        // Act
//        var lines = new List<string>();
//        await foreach (var line in fileReader.ReadLinesAsync(stream))
//        {
//            lines.Add(line);
//        }

//        // Assert
//        Assert.Equal(expectedLines, lines);
//    }

//    [Fact]
//    public async Task ReadLinesAsync_WithLinesEndingWithNewline_ReturnsCorrectLines()
//    {
//        // Arrange
//        var input = "Line 1\nLine 2\nLine 3\n";
//        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
//        var expectedLines = new List<string> { "Line 1", "Line 2", "Line 3" };

//        // Act
//        var lines = new List<string>();
//        await foreach (var line in fileReader.ReadLinesAsync(stream))
//        {
//            lines.Add(line);
//        }

//        // Assert
//        Assert.Equal(expectedLines, lines);
//    }
//}


using DemoAspose.FileReader;
using System.Text;

public class FileReaderTests
{
    private readonly IFileReader _fileReader;

    public FileReaderTests()
    {
        _fileReader = new FileReader();
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
        await Assert.ThrowsAsync<ArgumentException>(async() => await _fileReader.ReadLinesAsync(stream).ToListAsync());
    }

    [Fact]
    public async Task ReadLinesAsync_LineNumberTooHigh_ThrowsArgumentException()
    {
        // Arrange
        var input = "101\nLine 1\nLine 2\nLine 3\n";
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async() => await _fileReader.ReadLinesAsync(stream).ToListAsync());
    }

    [Fact]
    public async Task ReadLinesAsync_EmptyStream_ThrowsArgumentException()
    {
        // Arrange
        using var stream = new MemoryStream();

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () =>  await _fileReader.ReadLinesAsync(stream).ToListAsync());
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