using static RubiksCubeDemo.Models.FaceTypes;
using static RubiksCubeDemo.Models.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    public interface IRotationHandler
    {
        FaceType FaceType { get; }
        RotationType RotationType { get; }
        void Rotate();
    }
}
