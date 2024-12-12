
namespace DemoAspose.StreamCreator;
public interface IStreamCreator
{
    Stream CreateInputStream(string fileName);
    Stream CreateOutputStream(string fileName);
}