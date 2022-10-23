using Microsoft.Extensions.DependencyInjection;
using RubiksCubeDemo.Models;
using RubiksCubeDemo.Processor.Handlers;
using System.Reflection;
using static RubiksCubeDemo.Models.FaceTypes;

namespace RubiksCubeDemo.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCubeFaces(this IServiceCollection collection)
        {
            collection.AddSingleton<List<Face>>(new List<Face>
            {
                new Face(FaceType.Front),
                new Face(FaceType.Up),
                new Face(FaceType.Down),
                new Face(FaceType.Left),
                new Face(FaceType.Right),
                new Face(FaceType.Back)
            });
        }

        public static void RegisterRotationHandlers(this IServiceCollection collection, Assembly[] assemblies)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(IRotationHandler))));
            foreach (var type in typesFromAssemblies)
                collection.Add(new ServiceDescriptor(typeof(IRotationHandler), type, ServiceLifetime.Singleton));
        }
    }
}
