using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAspose.Reader
{
    public class FileWriter : IFileWriter
    {
        public async Task WriteLinesAsync(string filePath, IEnumerable<string> processedLines)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Output FilePath should not be empty");

            await File.WriteAllLinesAsync(filePath, processedLines);
        }
    }
}
