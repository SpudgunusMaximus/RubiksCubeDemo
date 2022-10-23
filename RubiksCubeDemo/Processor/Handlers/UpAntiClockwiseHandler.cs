using RubiksCubeDemo.Models;
using static RubiksCubeDemo.Models.FaceTypes;
using static RubiksCubeDemo.Models.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class UpAntiClockwiseHandler : RotationHandlerBase, IRotationHandler
    {
        public UpAntiClockwiseHandler(List<Face> faces) : base(faces, FaceType.Up, RotationType.AntiClockwise) { }

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

            rightFace.Cubies[0, 0] = frontFaceCubiesCopy[0, 0];
            rightFace.Cubies[1, 0] = frontFaceCubiesCopy[1, 0];
            rightFace.Cubies[2, 0] = frontFaceCubiesCopy[2, 0];

            frontFace.Cubies[0, 0] = leftFaceCubiesCopy[0, 0];
            frontFace.Cubies[1, 0] = leftFaceCubiesCopy[1, 0];
            frontFace.Cubies[2, 0] = leftFaceCubiesCopy[2, 0];

            leftFace.Cubies[0, 0] = backFaceCubiesCopy[0, 0];
            leftFace.Cubies[1, 0] = backFaceCubiesCopy[1, 0];
            leftFace.Cubies[2, 0] = backFaceCubiesCopy[2, 0];

            backFace.Cubies[0, 0] = rightFaceCubiesCopy[0, 0];
            backFace.Cubies[1, 0] = rightFaceCubiesCopy[1, 0];
            backFace.Cubies[2, 0] = rightFaceCubiesCopy[2, 0];

        }
    }
}
