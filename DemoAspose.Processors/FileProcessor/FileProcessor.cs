using DemoAspose.InputOutput.FileReader;
using DemoAspose.InputOutput.FileWriter;
using DemoAspose.Processors.LineProcessor;
using DemoAspose.StreamCreator;

namespace DemoAspose.Processors.FileProcessor;
public class FileProcessor : IFileProcessor
{
    private readonly IFileReader reader;
    private readonly IFileWriter writer;
    private readonly ILineProcessor lineProcessor;
    private readonly IStreamCreator streamCreator;

    public FileProcessor(IFileReader reader, IFileWriter writer, ILineProcessor lineProcessor, IStreamCreator streamCreator)
    {
        this.reader = reader;
        this.writer = writer;
        this.lineProcessor = lineProcessor;
        this.streamCreator = streamCreator;
    }

    public async Task Process(string inputFileName, string outputFileName)
    {
        using var inputStream = streamCreator.CreateInputStream(inputFileName);
        using var outputStream = streamCreator.CreateOutputStream(outputFileName);

        var processedLines = new List<string>();
        int lineNumber = 1;
        await foreach (var line in reader.ReadLinesAsync(inputStream))
        {
            processedLines.Add(lineProcessor.ProcessLine(lineNumber++, line));
        }

        await writer.WriteLinesAsync(outputStream, processedLines);
    }
}
