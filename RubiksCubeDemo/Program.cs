// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using RubiksCubeDemo;
using RubiksCubeDemo.ExtensionMethods;
using RubiksCubeDemo.Processor;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();
services.AddCubeFaces();
services.RegisterRotationHandlers(new[] { typeof(Program).Assembly }); ;
services.AddSingleton<IRotationProcessor, RotationProcessor>();
services.AddScoped<MainForm>();

using(ServiceProvider serviceProvider = services.BuildServiceProvider())
{
    var form = serviceProvider.GetService<MainForm>();
    Application.Run(form);
}




