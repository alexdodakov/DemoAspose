namespace DemoAspose.FileReader;
public interface IFileReader
{
    IAsyncEnumerable<string> ReadLinesAsync(Stream stream);

}