using RubiksCubeDemo.Models;
using static RubiksCubeDemo.Models.FaceTypes;
using static RubiksCubeDemo.Models.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    public class FrontAntiClockwiseHandler : RotationHandlerBase, IRotationHandler
    {
        public FrontAntiClockwiseHandler(IEnumerable<Face> faces) : base(faces, FaceType.Front, RotationType.AntiClockwise) { }
        public void Rotate()
        {
            Transpose();
            MoveNeighbours();
        }

        protected override void MoveNeighbours()
        {
            Face upFace = _faces.Single(f => f.FaceType == FaceType.Up);
            Face downFace = _faces.Single(f => f.FaceType == FaceType.Down);
            Face leftFace = _faces.Single(f => f.FaceType == FaceType.Left);
            Face rightFace = _faces.Single(f => f.FaceType == FaceType.Right);

            var upFaceCubiesCopy = (Color[,])upFace.Cubies.Clone();
            var downFaceCubiesCopy = (Color[,])downFace.Cubies.Clone();
            var leftFaceCubiesCopy = (Color[,])leftFace.Cubies.Clone();
            var rightFaceCubiesCopy = (Color[,])rightFace.Cubies.Clone();

            rightFace.Cubies[0, 0] = downFaceCubiesCopy[2, 0];
            rightFace.Cubies[0, 1] = downFaceCubiesCopy[1, 0];
            rightFace.Cubies[0, 2] = downFaceCubiesCopy[0, 0];

            downFace.Cubies[2, 0] = leftFaceCubiesCopy[2, 2];
            downFace.Cubies[1, 0] = leftFaceCubiesCopy[2, 1];
            downFace.Cubies[0, 0] = leftFaceCubiesCopy[2, 0];

            leftFace.Cubies[2, 2] = upFaceCubiesCopy[0, 2];
            leftFace.Cubies[2, 1] = upFaceCubiesCopy[1, 2];
            leftFace.Cubies[2, 0] = upFaceCubiesCopy[2, 2];

            upFace.Cubies[0, 2] = rightFaceCubiesCopy[0, 0];
            upFace.Cubies[1, 2] = rightFaceCubiesCopy[0, 1];
            upFace.Cubies[2, 2] = rightFaceCubiesCopy[0, 2];

        }

    }
}
