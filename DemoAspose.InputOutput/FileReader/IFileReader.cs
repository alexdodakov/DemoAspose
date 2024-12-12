namespace DemoAspose.InputOutput.FileReader;
public interface IFileReader
{
    IAsyncEnumerable<string> ReadLinesAsync(Stream stream);

}