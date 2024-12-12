namespace DemoAspose.Processors.FileProcessor;
public interface IFileProcessor
{
    Task Process(string inputFileName, string outputFileName);
}
