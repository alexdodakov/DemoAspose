//using System.Diagnostics;
//using System.IO;
//using System.Threading.Tasks;
//using Xunit;

//namespace MyApp.IntegrationTests
//{
//    public class ProgramTests
//    {
//        [Fact]
//        public async Task Main_WithValidInput_ReturnsExpectedOutput()
//        {
//            // Arrange
//            var input = "World";
//            var expectedOutput = "Hello, World!";

//            // Act
//            var output = await RunConsoleAppAsync(input);

//            // Assert
//            Assert.Contains(expectedOutput, output);
//        }

//        private async Task<string> RunConsoleAppAsync(string input)
//        {
//            var processStartInfo = new ProcessStartInfo
//            {
//                FileName = "dotnet",
//                Arguments = $"run --project ../DemoAspose/DemoAspose.csproj {input}",
//                RedirectStandardOutput = true,
//                UseShellExecute = false,
//                CreateNoWindow = true
//            };

//            using var process = new Process { StartInfo = processStartInfo };
//            process.Start();

//            // Read the output asynchronously
//            var output = await process.StandardOutput.ReadToEndAsync();
//            process.WaitForExit();

//            return output;
//        }
//    }
//}
