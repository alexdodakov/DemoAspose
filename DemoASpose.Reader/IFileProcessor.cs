
namespace DemoAspose.Reader
{
    public interface IFileProcessor
    {
        Task<(bool success, string fileName)> Process(string inputFilePath);
    }
}