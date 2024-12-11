namespace DemoAspose.FileProcessor;
public interface IFileProcessor
{
    Task Process(string inputFileName, string outputFileName);
}
