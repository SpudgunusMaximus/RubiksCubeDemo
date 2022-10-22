using static RubiksCubeDemo.FaceTypes;
using static RubiksCubeDemo.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class UpClockwiseHandler : RotationHandlerBase, IRotationHandler
    {
        public UpClockwiseHandler(List<Face> faces) : base(faces, FaceType.Up, RotationType.Clockwise) { }

        public void Rotate()
        {
            Transpose();
            MoveNeighbours();
        }

        protected override void MoveNeighbours()
        {
            Face frontFace = _faces.Single(f => f.FaceType == FaceType.Front);
            Face backFace = _faces.Single(f => f.FaceType == FaceType.Back);
            Face leftFace = _faces.Single(f => f.FaceType == FaceType.Left);
            Face rightFace = _faces.Single(f => f.FaceType == FaceType.Right);

            var frontFaceCubiesCopy = (Color[,])frontFace.Cubies.Clone();
            var backFaceCubiesCopy = (Color[,])backFace.Cubies.Clone();
            var leftFaceCubiesCopy = (Color[,])leftFace.Cubies.Clone();
            var rightFaceCubiesCopy = (Color[,])rightFace.Cubies.Clone();

            rightFace.Cubies[0, 0] = backFaceCubiesCopy[0, 0];
            rightFace.Cubies[0, 1] = backFaceCubiesCopy[0, 1];
            rightFace.Cubies[0, 2] = backFaceCubiesCopy[0, 2];

            frontFace.Cubies[0, 0] = rightFaceCubiesCopy[0, 0];
            frontFace.Cubies[0, 1] = rightFaceCubiesCopy[0, 1];
            frontFace.Cubies[0, 2] = rightFaceCubiesCopy[0, 2];

            leftFace.Cubies[0, 0] = frontFaceCubiesCopy[0, 0];
            leftFace.Cubies[0, 1] = frontFaceCubiesCopy[0, 1];
            leftFace.Cubies[0, 2] = frontFaceCubiesCopy[0, 2];

            backFace.Cubies[0, 0] = leftFaceCubiesCopy[0, 0];
            backFace.Cubies[0, 1] = leftFaceCubiesCopy[0, 1];
            backFace.Cubies[0, 2] = leftFaceCubiesCopy[0, 2];

        }
    }
}
