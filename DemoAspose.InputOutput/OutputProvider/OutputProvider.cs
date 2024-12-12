namespace DemoAspose.InputOutput.OutputProvider;
public class OutputProvider : IOutputProvider
{
    public void WriteLine(string text)
    {
        Console.WriteLine(text);
    }
}
