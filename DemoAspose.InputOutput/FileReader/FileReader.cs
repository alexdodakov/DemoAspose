namespace DemoAspose.InputOutput.FileReader;
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
}