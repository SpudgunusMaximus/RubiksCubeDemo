using static RubiksCubeDemo.FaceTypes;
using static RubiksCubeDemo.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class RightClockwiseHandler : RotationHandlerBase, IRotationHandler
    {
        public RightClockwiseHandler(List<Face> faces) : base(faces, FaceType.Right, RotationType.Clockwise) { }

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

            backFace.Cubies[0, 0] = upFaceCubiesCopy[2, 2];
            backFace.Cubies[1, 0] = upFaceCubiesCopy[1, 2];
            backFace.Cubies[2, 0] = upFaceCubiesCopy[0, 2];

            downFace.Cubies[2, 2] = backFaceCubiesCopy[0, 0];
            downFace.Cubies[1, 2] = backFaceCubiesCopy[1, 0];
            downFace.Cubies[0, 2] = backFaceCubiesCopy[2, 0];

            frontFace.Cubies[2, 2] = downFaceCubiesCopy[2, 2];
            frontFace.Cubies[1, 2] = downFaceCubiesCopy[1, 2];
            frontFace.Cubies[0, 2] = downFaceCubiesCopy[0, 2];

            upFace.Cubies[2, 2] = frontFaceCubiesCopy[2, 2];
            upFace.Cubies[1, 2] = frontFaceCubiesCopy[1, 2];
            upFace.Cubies[0, 2] = frontFaceCubiesCopy[0, 2];

        }
    }
}
