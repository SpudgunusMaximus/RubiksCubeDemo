using static RubiksCubeDemo.FaceTypes;
using static RubiksCubeDemo.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class DownAntiClockwiseHandler : RotationHandlerBase, IRotationHandler
    {
        public DownAntiClockwiseHandler(List<Face> faces) : base(faces, FaceType.Down, RotationType.AntiClockwise) { }

        public void Rotate()
        {
            Transpose();
            MoveNeighbours();
        }

        protected override void MoveNeighbours()
        {
            Face frontFace = _faces.Single(f => f.FaceType == FaceType.Front);
            Face rightFace = _faces.Single(f => f.FaceType == FaceType.Right);
            Face leftFace = _faces.Single(f => f.FaceType == FaceType.Left);
            Face backFace = _faces.Single(f => f.FaceType == FaceType.Back);

            var frontFaceCubiesCopy = (Color[,])frontFace.Cubies.Clone();
            var backFaceCubiesCopy = (Color[,])backFace.Cubies.Clone();
            var rightFaceCubiesCopy = (Color[,])rightFace.Cubies.Clone();
            var leftFaceCubiesCopy = (Color[,])leftFace.Cubies.Clone();

            rightFace.Cubies[2, 0] = backFaceCubiesCopy[2, 0];
            rightFace.Cubies[2, 1] = backFaceCubiesCopy[2, 1];
            rightFace.Cubies[2, 2] = backFaceCubiesCopy[2, 2];

            backFace.Cubies[2, 0] = leftFaceCubiesCopy[2, 0];
            backFace.Cubies[2, 1] = leftFaceCubiesCopy[2, 1];
            backFace.Cubies[2, 2] = leftFaceCubiesCopy[2, 2];

            leftFace.Cubies[2, 0] = frontFaceCubiesCopy[2, 0];
            leftFace.Cubies[2, 1] = frontFaceCubiesCopy[2, 1];
            leftFace.Cubies[2, 2] = frontFaceCubiesCopy[2, 2];

            frontFace.Cubies[2, 0] = frontFaceCubiesCopy[2, 0];
            frontFace.Cubies[2, 1] = frontFaceCubiesCopy[2, 1];
            frontFace.Cubies[2, 2] = frontFaceCubiesCopy[2, 2];

        }
    }
}
