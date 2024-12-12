namespace DemoAspose.InputOutput.FileWriter;
public interface IFileWriter
{
    Task WriteLinesAsync(Stream stream, IEnumerable<string> lines);
}
