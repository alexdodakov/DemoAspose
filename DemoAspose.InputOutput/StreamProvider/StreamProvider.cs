namespace DemoAspose.InputOutput.StreamProvider;
public class StreamProvider : IStreamProvider
{
    public Stream CreateInputStream(string fileName)
    {
        return new FileStream(fileName, FileMode.Open, FileAccess.Read);
    }

    public Stream CreateOutputStream(string fileName)
    {
        return File.Create(fileName);
    }
}