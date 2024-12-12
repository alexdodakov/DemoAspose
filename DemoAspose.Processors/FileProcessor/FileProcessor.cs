using DemoAspose.InputOutput.FileReader;
using DemoAspose.InputOutput.FileWriter;
using DemoAspose.InputOutput.StreamProvider;
using DemoAspose.Processors.LineProcessor;

namespace DemoAspose.Processors.FileProcessor;
public class FileProcessor : IFileProcessor
{
    private readonly IFileReader reader;
    private readonly IFileWriter writer;
    private readonly ILineProcessor lineProcessor;
    private readonly IStreamProvider StreamProvider;

    public FileProcessor(IFileReader reader, IFileWriter writer, ILineProcessor lineProcessor, IStreamProvider StreamProvider)
    {
        this.reader = reader;
        this.writer = writer;
        this.lineProcessor = lineProcessor;
        this.StreamProvider = StreamProvider;
    }

    public async Task Process(string inputFileName, string outputFileName)
    {
        using var inputStream = StreamProvider.CreateInputStream(inputFileName);
        using var outputStream = StreamProvider.CreateOutputStream(outputFileName);

        var processedLines = new List<string>();
        int lineNumber = 1;
        await foreach (var line in reader.ReadLinesAsync(inputStream))
        {
            processedLines.Add(lineProcessor.ProcessLine(lineNumber++, line));
        }

        await writer.WriteLinesAsync(outputStream, processedLines);
    }
}
