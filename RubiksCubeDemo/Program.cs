// See https://aka.ms/new-console-template for more information
using RubiksCubeDemo;
using RubiksCubeDemo.Processor;
using static RubiksCubeDemo.FaceTypes;

Console.WriteLine("Hello, World!");

List<Face> faceList = new List<Face>
{
    new Face(FaceType.Front),
    new Face(FaceType.Up),
    new Face(FaceType.Down),
    new Face(FaceType.Left),
    new Face(FaceType.Right)
};

RotationProcessor processor = new RotationProcessor(faceList);

processor.RotateFace(FaceType.Front);

Console.ReadLine();


