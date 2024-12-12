namespace DemoAspose.InputOutput.StreamProvider;
public interface IStreamProvider
{
    Stream CreateInputStream(string fileName);
    Stream CreateOutputStream(string fileName);
}