using static RubiksCubeDemo.FaceTypes;
using static RubiksCubeDemo.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    public interface IRotationHandler
    {
        FaceType FaceType { get; }
        RotationType RotationType { get; }
        void Rotate();
    }
}
