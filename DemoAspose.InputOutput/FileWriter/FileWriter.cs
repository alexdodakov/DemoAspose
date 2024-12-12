using System.Text;

namespace DemoAspose.InputOutput.FileWriter;
public class FileWriter : IFileWriter
{
    public async Task WriteLinesAsync(Stream stream, IEnumerable<string> lines)
    {
        var text = lines == null || lines.Count() == 0
            ? string.Empty
            : string.Join(Environment.NewLine, lines);
        using var writer = new StreamWriter(stream, Encoding.UTF8);
        await writer.WriteAsync(text);
    }
}