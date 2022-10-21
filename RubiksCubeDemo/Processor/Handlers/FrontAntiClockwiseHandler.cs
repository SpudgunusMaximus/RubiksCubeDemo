using static RubiksCubeDemo.FaceTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class FrontAntiClockwiseHandler
    {
        private readonly List<Face> _faces;

        public FrontAntiClockwiseHandler(List<Face> faces)
        {
            _faces = faces;
        }

        public void MoveNeighbours()
        {
            Face upFace = _faces.Single(f => f.FaceType == FaceType.Up);
            Face downFace = _faces.Single(f => f.FaceType == FaceType.Down);
            Face leftFace = _faces.Single(f => f.FaceType == FaceType.Left);
            Face rightFace = _faces.Single(f => f.FaceType == FaceType.Right);

            var upFaceCubiesCopy = (int[,])upFace.Cubies.Clone();
            var downFaceCubiesCopy = (int[,])downFace.Cubies.Clone();
            var leftFaceCubiesCopy = (int[,])leftFace.Cubies.Clone();
            var rightFaceCubiesCopy = (int[,])rightFace.Cubies.Clone();

            rightFace.Cubies[0, 0] = downFaceCubiesCopy[0, 2];
            rightFace.Cubies[1, 0] = downFaceCubiesCopy[0, 1];
            rightFace.Cubies[2, 0] = downFaceCubiesCopy[0, 0];

            downFace.Cubies[0, 2] = leftFaceCubiesCopy[2, 2];
            downFace.Cubies[0, 1] = leftFaceCubiesCopy[1, 2];
            downFace.Cubies[0, 0] = leftFaceCubiesCopy[0, 2];

            leftFace.Cubies[2, 2] = upFaceCubiesCopy[2, 0];
            leftFace.Cubies[1, 2] = upFaceCubiesCopy[2, 1];
            leftFace.Cubies[0, 2] = upFaceCubiesCopy[2, 2];

            upFace.Cubies[2, 0] = rightFaceCubiesCopy[0, 0];
            upFace.Cubies[2, 1] = rightFaceCubiesCopy[1, 0];
            upFace.Cubies[2, 2] = rightFaceCubiesCopy[2, 0];

        }

    }
}
