using static RubiksCubeDemo.FaceTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class BackAntiClockwiseHandler
    {
        private readonly List<Face> _faces;

        public BackAntiClockwiseHandler(List<Face> faces)
        {
            _faces = faces;
        }

        public void MoveNeighbours()
        {
            Face leftFace = _faces.Single(f => f.FaceType == FaceType.Left);
            Face downFace = _faces.Single(f => f.FaceType == FaceType.Down);
            Face rightFace = _faces.Single(f => f.FaceType == FaceType.Right);
            Face upFace = _faces.Single(f => f.FaceType == FaceType.Up);

            var leftFaceCubiesCopy = (int[,])leftFace.Cubies.Clone();
            var downFaceCubiesCopy = (int[,])downFace.Cubies.Clone();
            var rightFaceCubiesCopy = (int[,])rightFace.Cubies.Clone();
            var upFaceCubiesCopy = (int[,])upFace.Cubies.Clone();

            leftFace.Cubies[0, 0] = downFaceCubiesCopy[2, 0];
            leftFace.Cubies[1, 0] = downFaceCubiesCopy[2, 1];
            leftFace.Cubies[2, 0] = downFaceCubiesCopy[2, 2];

            downFace.Cubies[2, 0] = rightFaceCubiesCopy[2, 2];
            downFace.Cubies[2, 1] = rightFaceCubiesCopy[1, 2];
            downFace.Cubies[2, 2] = rightFaceCubiesCopy[0, 2];

            rightFace.Cubies[2, 2] = upFaceCubiesCopy[0, 2];
            rightFace.Cubies[1, 2] = upFaceCubiesCopy[0, 1];
            rightFace.Cubies[0, 2] = upFaceCubiesCopy[0, 0];

            upFace.Cubies[0, 2] = leftFaceCubiesCopy[0, 0];
            upFace.Cubies[0, 1] = leftFaceCubiesCopy[1, 0];
            upFace.Cubies[0, 0] = leftFaceCubiesCopy[2, 0];

        }
    }
}
