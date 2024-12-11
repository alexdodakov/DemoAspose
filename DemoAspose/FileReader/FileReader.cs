namespace DemoAspose.FileReader;
public class FileReader : IFileReader
{
    public async IAsyncEnumerable<string> ReadLinesAsync(Stream stream)
    { 
        using var streamReader = new StreamReader(stream);
        var firstLine = await streamReader.ReadLineAsync();
        if (string.IsNullOrEmpty(firstLine) 
            || !int.TryParse(firstLine, out int lineNumber)
            || lineNumber < 0 
            || lineNumber > 100)
            throw new ArgumentException("Incorrect linenumber parameter");

        int i = 0;
        while (i < lineNumber && !streamReader.EndOfStream)
        {
            yield return await streamReader.ReadLineAsync();
        }
    }

    //public async IAsyncEnumerable<string> ReadLinesAsync(string filePath)
    //{
    //    if (string.IsNullOrEmpty(filePath))
    //        throw new ArgumentException("Output FilePath should not be empty");

    //    if (!File.Exists(filePath))
    //        throw new FileNotFoundException($"File not found: {filePath}");

    //    using var streamReader = new StreamReader(filePath);
    //    while (!streamReader.EndOfStream)
    //    {
    //        yield return await streamReader.ReadLineAsync();
    //    }
    //}

    // public StreamReader CreateStreamReader(string filePath) => new StreamReader(filePath);
}