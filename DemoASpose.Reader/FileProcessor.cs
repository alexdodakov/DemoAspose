namespace DemoAspose.Reader
{
    public class FileProcessor : IFileProcessor
    {
        private readonly IFileReader reader;
        private readonly IFileWriter writer;
        private readonly ILineProcessor lineProcessor;

        public FileProcessor(IFileReader reader, IFileWriter writer, ILineProcessor lineProcessor)
        {
            this.reader = reader;
            this.writer = writer;
            this.lineProcessor = lineProcessor;
        }

        public async Task<(bool success, string fileName)> Process(string inputFilePath)
        {
            try
            {
                var processedLines = new List<string>();
                await foreach (var line in reader.ReadLinesAsync(inputFilePath))
                {
                    processedLines.Add(lineProcessor.ProcessLine(line));
                }

                var outputFilePath = GetOutputFilePath(inputFilePath);
                await writer.WriteLinesAsync(GetOutputFilePath(inputFilePath), processedLines.ToArray());

                return (true, $"Successfully converted. Output file: {outputFilePath}");
            }
            catch (Exception ex)
            {

                return (false, $"Convertion failed with error: {ex.Message}");
            }
        }

        private string GetOutputFilePath(string inputFilePath) => $"{inputFilePath}_Output";


        //if (string.IsNullOrEmpty(inputFileName))
        //{
        //    return (false, "Input file name is empty");
        //}

        //if (File.Exists(inputFileName))
        //{
        //    return (false, "File does not exists");
        //}

        //using var inputFileStream = File.OpenRead(inputFileName);
        //using var outputFileStream = File.OpenWrite(inputFileName);
        //File.Re
        //await foreach (var line in reader.ReadStringsFromStreamAsync(inputFileStream))
        //{
        //    var convertedString = converter.Convert(line);
        //    writer.Write(outputFileStream, convertedString);
        //}
    }
}
