using RubiksCubeDemo.Models;
using static RubiksCubeDemo.Models.FaceTypes;
using static RubiksCubeDemo.Models.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    public class BackAntiClockwiseHandler : RotationHandlerBase, IRotationHandler
    {
        public BackAntiClockwiseHandler(List<Face> faces) : base(faces, FaceType.Back, RotationType.AntiClockwise) { }
        public void Rotate()
        {
            Transpose();
            MoveNeighbours();
        }

        protected override void MoveNeighbours()
        {
            Face leftFace = _faces.Single(f => f.FaceType == FaceType.Left);
            Face downFace = _faces.Single(f => f.FaceType == FaceType.Down);
            Face rightFace = _faces.Single(f => f.FaceType == FaceType.Right);
            Face upFace = _faces.Single(f => f.FaceType == FaceType.Up);

            var leftFaceCubiesCopy = (Color[,])leftFace.Cubies.Clone();
            var downFaceCubiesCopy = (Color[,])downFace.Cubies.Clone();
            var rightFaceCubiesCopy = (Color[,])rightFace.Cubies.Clone();
            var upFaceCubiesCopy = (Color[,])upFace.Cubies.Clone();

            leftFace.Cubies[0, 0] = downFaceCubiesCopy[0, 2];
            leftFace.Cubies[0, 1] = downFaceCubiesCopy[1, 2];
            leftFace.Cubies[0, 2] = downFaceCubiesCopy[2, 2];

            downFace.Cubies[2, 2] = rightFaceCubiesCopy[2, 0];
            downFace.Cubies[1, 2] = rightFaceCubiesCopy[2, 1];
            downFace.Cubies[0, 2] = rightFaceCubiesCopy[2, 2];

            rightFace.Cubies[2, 2] = upFaceCubiesCopy[2, 0];
            rightFace.Cubies[2, 1] = upFaceCubiesCopy[1, 0];
            rightFace.Cubies[2, 0] = upFaceCubiesCopy[0, 0];

            upFace.Cubies[2, 0] = leftFaceCubiesCopy[0, 0];
            upFace.Cubies[1, 0] = leftFaceCubiesCopy[0, 1];
            upFace.Cubies[0, 0] = leftFaceCubiesCopy[0, 2];

        }
    }
}
