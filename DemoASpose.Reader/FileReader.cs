using System.Text;

namespace DemoAspose.Reader
{
    public class FileReader : IFileReader
    {
        public FileReader()
        {

        }

        public async IAsyncEnumerable<string> ReadLinesAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Output FilePath should not be empty" );

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            using var streamReader = new StreamReader(filePath);
            while (!streamReader.EndOfStream)
            {
                yield return await streamReader.ReadLineAsync();
            }
        }

        //public async IAsyncEnumerable<string> ProcessTextFileAsync(string filePath)
        //{
        //    await using var fileStream = File.OpenRead(filePath);
        //    await foreach (var line in ReadStringsFromStreamAsync(fileStream))
        //    {
        //        yield return line;
        //    }
        //}

        //public async IAsyncEnumerable<string> ReadStringsFromStreamAsync(Stream stream)
        //{
        //    using (var reader = new StreamReader(stream, Encoding.UTF8))
        //    {
        //        string line;
        //        while ((line = await reader.ReadLineAsync()) != null)
        //        {
        //            yield return line;
        //        }
        //    }
        //}

    }
}