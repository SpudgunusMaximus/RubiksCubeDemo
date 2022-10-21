using static RubiksCubeDemo.FaceTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class BackClockwiseHandler
    {
        private readonly List<Face> _faces;

        public BackClockwiseHandler(List<Face> faces)
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
