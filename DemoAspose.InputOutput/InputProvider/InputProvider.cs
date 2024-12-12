namespace DemoAspose.InputOutput.InputProvider;
public class InputProvider : IInputProvider
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}