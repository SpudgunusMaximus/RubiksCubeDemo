using static RubiksCubeDemo.FaceTypes;
using static RubiksCubeDemo.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class BackClockwiseHandler : RotationHandlerBase, IRotationHandler
    {
        public BackClockwiseHandler(List<Face> faces) : base(faces, FaceType.Back, RotationType.Clockwise) { }
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

            leftFace.Cubies[0, 0] = upFaceCubiesCopy[0, 2];
            leftFace.Cubies[1, 0] = upFaceCubiesCopy[0, 1];
            leftFace.Cubies[2, 0] = upFaceCubiesCopy[0, 0];

            downFace.Cubies[2, 0] = leftFaceCubiesCopy[0, 0];
            downFace.Cubies[2, 1] = leftFaceCubiesCopy[1, 0];
            downFace.Cubies[2, 2] = leftFaceCubiesCopy[2, 0];

            rightFace.Cubies[2, 2] = downFaceCubiesCopy[2, 0];
            rightFace.Cubies[1, 2] = downFaceCubiesCopy[2, 1];
            rightFace.Cubies[0, 2] = downFaceCubiesCopy[2, 2];

            upFace.Cubies[0, 2] = rightFaceCubiesCopy[2, 2];
            upFace.Cubies[0, 1] = rightFaceCubiesCopy[1, 2];
            upFace.Cubies[0, 0] = rightFaceCubiesCopy[0, 2];

        }
    }
}
