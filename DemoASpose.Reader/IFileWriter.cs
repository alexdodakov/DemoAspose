using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAspose.Reader
{
    public interface IFileWriter
    {
        Task WriteLinesAsync(string filePath, IEnumerable<string> processedLines);
    }
}
