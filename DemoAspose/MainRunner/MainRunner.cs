using DemoAspose.InputOutput.InputProvider;
using DemoAspose.InputOutput.OutputProvider;
using DemoAspose.Processors.FileProcessor;

namespace DemoAspose.MainRunner;

public class MainRunner : IMainRunner
{
    private readonly IFileProcessor fileProcessor;
    private readonly IInputProvider inputProvider;
    private readonly IOutputProvider outputProvider;

    public MainRunner(
        IFileProcessor fileProcessor, 
        IInputProvider inputProvider, 
        IOutputProvider outputProvider)
    {
        this.fileProcessor = fileProcessor;
        this.inputProvider = inputProvider;
        this.outputProvider = outputProvider;
    }

    public async Task RunProgram()
    {
        try
        {
            outputProvider.WriteLine("Please inputfilename(e.g. sample.txt)");
            var inputFileName = inputProvider.ReadLine();
            var outputFileName = $"{DateTime.Now:yyyyMMddHHmmss}_output_{inputFileName}";

            if (string.IsNullOrEmpty(inputFileName))
                throw new ArgumentException($"FileName was not provided");

            if (!File.Exists(inputFileName))
                throw new FileNotFoundException($"File not found- {inputFileName}");

            await fileProcessor.Process(inputFileName, outputFileName);

            outputProvider.WriteLine($"Successfully converted to {outputFileName}");

            inputProvider.ReadLine();

        }
        catch (Exception ex)
        {
            outputProvider.WriteLine($"Convertion failed with error: {ex.Message}");
        }
    }
}
