using DemoAspose.FileProcessor;
using Microsoft.Extensions.DependencyInjection;

try
{
    var serviceProvider = Startup.ConfigureServices();
    var fileProcessor = serviceProvider.GetService<IFileProcessor>();   

    var inputFileName = "sample.txt";
    var outputFileName = $"{DateTime.Now:yyyyMMddHHmmss}_output_sample.txt";

    if (!File.Exists(inputFileName))
        throw new FileNotFoundException($"File not found: {inputFileName}");     

    await fileProcessor.Process(inputFileName, outputFileName);

    Console.WriteLine($"Successfully converted to {outputFileName}");

    Console.ReadLine();

}
catch (Exception ex) 
{
    Console.WriteLine($"Convertion failed with error: {ex.Message}");
}


//try
//{
//    var serviceProvider = Startup.ConfigureServices();
//    var fileProcessor = serviceProvider.GetService<IStreamProcessor>();

//    var fileName = "sample.txt";
//    var outputFileName = $"{DateTime.Now:yyyyMMddHHmmss}_output_sample.txt";

//    if (!File.Exists(fileName))
//        throw new FileNotFoundException($"File not found: {fileName}");

//    using var inputStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
//    using var outputStream = File.Create(outputFileName);

//    await fileProcessor.Process(inputStream, outputStream);

//    Console.WriteLine($"Successfully converted to {outputFileName}");

//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Convertion failed with error: {ex.Message}");
//}



