using RubiksCubeDemo.Models;
using static RubiksCubeDemo.Models.FaceTypes;
using static RubiksCubeDemo.Models.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class LeftClockwiseHandler : RotationHandlerBase, IRotationHandler
    {
        public LeftClockwiseHandler(List<Face> faces) : base(faces, FaceType.Left, RotationType.Clockwise) { }

        public void Rotate()
        {
            Transpose();
            MoveNeighbours();
        }

        protected override void MoveNeighbours()
        {
            Face upFace = _faces.Single(f => f.FaceType == FaceType.Up);
            Face frontFace = _faces.Single(f => f.FaceType == FaceType.Front);
            Face downFace = _faces.Single(f => f.FaceType == FaceType.Down);
            Face backFace = _faces.Single(f => f.FaceType == FaceType.Back);

            var frontFaceCubiesCopy = (Color[,])frontFace.Cubies.Clone();
            var backFaceCubiesCopy = (Color[,])backFace.Cubies.Clone();
            var downFaceCubiesCopy = (Color[,])downFace.Cubies.Clone();
            var upFaceCubiesCopy = (Color[,])upFace.Cubies.Clone();

            frontFace.Cubies[0, 0] = upFaceCubiesCopy[0, 0];
            frontFace.Cubies[0, 1] = upFaceCubiesCopy[0, 1];
            frontFace.Cubies[0, 2] = upFaceCubiesCopy[0, 2];

            downFace.Cubies[0, 0] = frontFaceCubiesCopy[0, 0];
            downFace.Cubies[0, 1] = frontFaceCubiesCopy[0, 1];
            downFace.Cubies[0, 2] = frontFaceCubiesCopy[0, 2];

            backFace.Cubies[2, 0] = downFaceCubiesCopy[0, 2];
            backFace.Cubies[2, 1] = downFaceCubiesCopy[0, 1];
            backFace.Cubies[2, 2] = downFaceCubiesCopy[0, 0];

            upFace.Cubies[0, 2] = backFaceCubiesCopy[2, 0];
            upFace.Cubies[0, 1] = backFaceCubiesCopy[2, 1];
            upFace.Cubies[0, 0] = backFaceCubiesCopy[2, 2];

        }
    }
}
