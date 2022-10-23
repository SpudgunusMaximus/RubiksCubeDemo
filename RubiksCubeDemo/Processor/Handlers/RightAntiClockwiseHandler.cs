using RubiksCubeDemo.Models;
using static RubiksCubeDemo.Models.FaceTypes;
using static RubiksCubeDemo.Models.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class RightAntiClockwiseHandler : RotationHandlerBase, IRotationHandler
    {
        public RightAntiClockwiseHandler(List<Face> faces) : base(faces, FaceType.Right, RotationType.AntiClockwise) { }

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

            backFace.Cubies[0, 0] = downFaceCubiesCopy[2, 2];
            backFace.Cubies[0, 1] = downFaceCubiesCopy[2, 1];
            backFace.Cubies[0, 2] = downFaceCubiesCopy[2, 0];

            downFace.Cubies[2, 2] = frontFaceCubiesCopy[2, 2];
            downFace.Cubies[2, 1] = frontFaceCubiesCopy[2, 1];
            downFace.Cubies[2, 0] = frontFaceCubiesCopy[2, 0];

            frontFace.Cubies[2, 2] = upFaceCubiesCopy[2, 2];
            frontFace.Cubies[2, 1] = upFaceCubiesCopy[2, 1];
            frontFace.Cubies[2, 0] = upFaceCubiesCopy[2, 0];

            upFace.Cubies[2, 2] = backFaceCubiesCopy[0, 0];
            upFace.Cubies[2, 1] = backFaceCubiesCopy[0, 1];
            upFace.Cubies[2, 0] = backFaceCubiesCopy[0, 2];

        }
    }
}
