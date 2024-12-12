using DemoAspose.InputOutput.FileReader;
using DemoAspose.InputOutput.FileWriter;
using DemoAspose.InputOutput.InputProvider;
using DemoAspose.InputOutput.OutputProvider;
using DemoAspose.InputOutput.StreamProvider;
using DemoAspose.MainRunner;
using DemoAspose.Processors.FileProcessor;
using DemoAspose.Processors.LineProcessor;
using Microsoft.Extensions.DependencyInjection;

public static class Startup
{
    public static ServiceProvider ConfigureServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IFileReader, FileReader>()
            .AddTransient<IFileWriter, FileWriter>()
            .AddTransient<ILineProcessor, LineProcessor>()
            .AddTransient<IFileProcessor, FileProcessor>()
            .AddTransient<IStreamProvider, StreamProvider>()
            .AddTransient<IInputProvider, InputProvider>()
            .AddTransient<IOutputProvider, OutputProvider>()
            .AddTransient<IMainRunner, MainRunner>()

            .BuildServiceProvider();

        return serviceProvider;
    }
}
