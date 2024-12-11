using DemoAspose.FileProcessor;
using DemoAspose.FileReader;
using DemoAspose.FileWriter;
using DemoAspose.LineProcessor;
using DemoAspose.StreamCreator;
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
            .AddTransient<IStreamCreator, StreamCreator>()
            .BuildServiceProvider();

        return serviceProvider;
    }
}
