using DemoAspose.InputOutput.InputProvider;
using DemoAspose.InputOutput.OutputProvider;
using DemoAspose.Processors.FileProcessor;
using Moq;

namespace DemoAspose.Tests.MainRunner;
public class MainRunnerTests
{
    private readonly Mock<IFileProcessor> _mockFileProcessor;
    private readonly Mock<IInputProvider> _mockInputProvider;
    private readonly Mock<IOutputProvider> _mockOutputProvider;
    private readonly DemoAspose.MainRunner.MainRunner _mainRunner;

    public MainRunnerTests()
    {
        _mockFileProcessor = new Mock<IFileProcessor>();
        _mockInputProvider = new Mock<IInputProvider>();
        _mockOutputProvider = new Mock<IOutputProvider>();
        _mainRunner = new DemoAspose.MainRunner.MainRunner(_mockFileProcessor.Object, _mockInputProvider.Object, _mockOutputProvider.Object);
    }

    [Fact]
    public async Task RunProgram_ShouldPromptForFileName()
    {
        // Arrange
        _mockOutputProvider.Setup(op => op.WriteLine(It.IsAny<string>()));
        _mockInputProvider.SetupSequence(ip => ip.ReadLine())
            .Returns("sample.txt");

        // Act
        await _mainRunner.RunProgram();

        // Assert
        _mockOutputProvider.Verify(op => op.WriteLine("Please inputfilename(e.g. sample.txt)"), Times.Once);
    }

    [Fact]
    public async Task RunProgram_ShouldThrowArgumentException_WhenFileNameNotProvided()
    {
        // Arrange
        _mockOutputProvider.Setup(op => op.WriteLine(It.IsAny<string>()));
        _mockInputProvider.SetupSequence(ip => ip.ReadLine())
            .Returns(string.Empty); // Simulate no input

        // Act & Assert
        await _mainRunner.RunProgram();
        _mockOutputProvider.Verify(x => x.WriteLine("Convertion failed with error: FileName was not provided"), Times.AtLeastOnce());
    }

    [Fact]
    public async Task RunProgram_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
    {
        // Arrange
        _mockOutputProvider.Setup(op => op.WriteLine(It.IsAny<string>()));
        _mockInputProvider.SetupSequence(ip => ip.ReadLine())
            .Returns("nonexistent.txt");

        // Simulate that the file does not exist
        _mockFileProcessor.Setup(fp => fp.Process(It.IsAny<string>(), It.IsAny<string>()))
            .Throws(new FileNotFoundException("File not found: nonexistent.txt"));

        // Act & Assert
        await _mainRunner.RunProgram();
        _mockOutputProvider.Verify(x => x.WriteLine("Convertion failed with error: File not found- nonexistent.txt"), Times.AtLeastOnce());
    }

    [Fact]
    public async Task RunProgram_ShouldProcessFile_WhenFileExists()
    {
        // Arrange
        var inputFileName = "sample.txt";
        var outputFileName = $"{DateTime.Now:yyyyMMddHHmmss}_output_{inputFileName}";

        _mockOutputProvider.Setup(op => op.WriteLine(It.IsAny<string>()));
        _mockInputProvider.SetupSequence(ip => ip.ReadLine())
            .Returns(inputFileName);

        // Simulate that the file exists
        _mockFileProcessor.Setup(fp => fp.Process(inputFileName, outputFileName)).Returns(Task.CompletedTask);

        // Act
        await _mainRunner.RunProgram();

        // Assert
        _mockFileProcessor.Verify(fp => fp.Process(inputFileName, outputFileName), Times.Once);
        _mockOutputProvider.Verify(op => op.WriteLine($"Successfully converted to {outputFileName}"), Times.Once);
    }

    [Fact]
    public async Task RunProgram_ShouldHandleExceptions_WhenProcessingFails()
    {
        // Arrange
        var inputFileName = "sample.txt";
        _mockOutputProvider.Setup(op => op.WriteLine(It.IsAny<string>()));
        _mockInputProvider.SetupSequence(ip => ip.ReadLine())
            .Returns(inputFileName);

        // Simulate that the file exists
        _mockFileProcessor.Setup(fp => fp.Process(inputFileName, It.IsAny<string>()))
            .Throws(new Exception("Processing error"));

        // Act
        await _mainRunner.RunProgram();

        // Assert
        _mockOutputProvider.Verify(op => op.WriteLine("Convertion failed with error: Processing error"), Times.Once);
    }
}
