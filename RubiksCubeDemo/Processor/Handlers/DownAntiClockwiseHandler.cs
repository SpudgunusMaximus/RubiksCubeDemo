using RubiksCubeDemo.Models;
using static RubiksCubeDemo.Models.FaceTypes;
using static RubiksCubeDemo.Models.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    public class DownAntiClockwiseHandler : RotationHandlerBase, IRotationHandler
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

            rightFace.Cubies[0, 2] = backFaceCubiesCopy[0, 2];
            rightFace.Cubies[1, 2] = backFaceCubiesCopy[1, 2];
            rightFace.Cubies[2, 2] = backFaceCubiesCopy[2, 2];

            backFace.Cubies[0, 2] = leftFaceCubiesCopy[0, 2];
            backFace.Cubies[1, 2] = leftFaceCubiesCopy[1, 2];
            backFace.Cubies[2, 2] = leftFaceCubiesCopy[2, 2];

            leftFace.Cubies[0, 2] = frontFaceCubiesCopy[0, 2];
            leftFace.Cubies[1, 2] = frontFaceCubiesCopy[1, 2];
            leftFace.Cubies[2, 2] = frontFaceCubiesCopy[2, 2];

            frontFace.Cubies[0, 2] = rightFaceCubiesCopy[0, 2];
            frontFace.Cubies[1, 2] = rightFaceCubiesCopy[1, 2];
            frontFace.Cubies[2, 2] = rightFaceCubiesCopy[2, 2];

        }
    }
}
