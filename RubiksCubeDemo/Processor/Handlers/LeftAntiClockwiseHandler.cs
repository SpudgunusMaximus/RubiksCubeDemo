using static RubiksCubeDemo.FaceTypes;
using static RubiksCubeDemo.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class LeftAntiClockwiseHandler : RotationHandlerBase, IRotationHandler
    {
        public LeftAntiClockwiseHandler(List<Face> faces) : base(faces, FaceType.Left, RotationType.AntiClockwise) { }

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

            frontFace.Cubies[0, 0] = downFaceCubiesCopy[0, 0];
            frontFace.Cubies[1, 0] = downFaceCubiesCopy[1, 0];
            frontFace.Cubies[2, 0] = downFaceCubiesCopy[2, 0];

            downFace.Cubies[0, 0] = backFaceCubiesCopy[2, 2];
            downFace.Cubies[1, 0] = backFaceCubiesCopy[1, 2];
            downFace.Cubies[2, 0] = backFaceCubiesCopy[0, 2];

            backFace.Cubies[0, 2] = upFaceCubiesCopy[2, 0];
            backFace.Cubies[1, 2] = upFaceCubiesCopy[1, 0];
            backFace.Cubies[2, 2] = upFaceCubiesCopy[0, 0];

            upFace.Cubies[2, 0] = frontFaceCubiesCopy[0, 0];
            upFace.Cubies[1, 0] = frontFaceCubiesCopy[1, 0];
            upFace.Cubies[0, 0] = frontFaceCubiesCopy[2, 0];

        }
    }
}
