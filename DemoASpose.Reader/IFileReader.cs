
namespace DemoAspose.Reader
{
    public interface IFileReader
    {
        IAsyncEnumerable<string> ReadLinesAsync(string filePath);
    }
}