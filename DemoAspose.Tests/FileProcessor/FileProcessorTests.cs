using DemoAspose.FileProcessor;
using DemoAspose.FileReader;
using DemoAspose.FileWriter;
using DemoAspose.LineProcessor;
using DemoAspose.StreamCreator;
using Moq;

public class FileProcessorTests
{
    private readonly Mock<IFileReader> mockReader;
    private readonly Mock<IFileWriter> mockWriter;
    private readonly Mock<ILineProcessor> mockLineProcessor;
    private readonly Mock<IStreamCreator> mockStreamCreator;
    private readonly FileProcessor streamProcessor;

    public FileProcessorTests()
    {
        mockReader = new Mock<IFileReader>();
        mockWriter = new Mock<IFileWriter>();
        mockLineProcessor = new Mock<ILineProcessor>();
        mockStreamCreator = new Mock<IStreamCreator>();
        streamProcessor = new FileProcessor(mockReader.Object, mockWriter.Object, mockLineProcessor.Object, mockStreamCreator.Object);
    }   

    [Fact]
    public async Task Process_ValidInput_ProcessesAndWritesLines()
    {
        // Arrange
        var inputFileName = "input.txt";
        var outputFileName = "output.txt";
        var lines = new List<string> { "line1", "line2", "line3" };
        var processedLines = new List<string> { "processed line1", "processed line2", "processed line3" };

        mockReader.Setup(r => r.ReadLinesAsync(It.IsAny<Stream>())).Returns(GetAsyncStream(lines));
        mockLineProcessor.Setup(lp => lp.ProcessLine(It.IsAny<int>(), It.IsAny<string>())).Returns((int lineNumber, string line) => $"processed {line}");
        mockStreamCreator.Setup(sc => sc.CreateInputStream(inputFileName)).Returns(new MemoryStream());
        mockStreamCreator.Setup(sc => sc.CreateOutputStream(outputFileName)).Returns(new MemoryStream());

        // Act
        await streamProcessor.Process(inputFileName, outputFileName);

        // Assert
        mockReader.Verify(r => r.ReadLinesAsync(It.IsAny<Stream>()), Times.Once);
        mockWriter.Verify(w => w.WriteLinesAsync(It.IsAny<Stream>(), processedLines), Times.Once);
    }

    private async IAsyncEnumerable<string> GetAsyncStream(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            yield return line;
            await Task.Yield();
        }
    }
}
