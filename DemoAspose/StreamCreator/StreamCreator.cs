namespace DemoAspose.StreamCreator;
public class StreamCreator : IStreamCreator
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