using DemoAspose.MainRunner;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = Startup.ConfigureServices();
var runner = serviceProvider.GetService<IMainRunner>();   
await runner.RunProgram();