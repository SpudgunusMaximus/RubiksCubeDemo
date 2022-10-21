using static RubiksCubeDemo.FaceTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class DownClockwiseHandler
    {
        private readonly List<Face> _faces;

        public DownClockwiseHandler(List<Face> faces)
        {
            _faces = faces;
        }

        public void MoveNeighbours()
        {
            Face frontFace = _faces.Single(f => f.FaceType == FaceType.Front);
            Face rightFace = _faces.Single(f => f.FaceType == FaceType.Right);
            Face leftFace = _faces.Single(f => f.FaceType == FaceType.Left);
            Face backFace = _faces.Single(f => f.FaceType == FaceType.Back);

            var frontFaceCubiesCopy = (int[,])frontFace.Cubies.Clone();
            var backFaceCubiesCopy = (int[,])backFace.Cubies.Clone();
            var rightFaceCubiesCopy = (int[,])rightFace.Cubies.Clone();
            var leftFaceCubiesCopy = (int[,])leftFace.Cubies.Clone();

            rightFace.Cubies[2, 0] = frontFaceCubiesCopy[2, 0];
            rightFace.Cubies[2, 1] = frontFaceCubiesCopy[2, 1];
            rightFace.Cubies[2, 2] = frontFaceCubiesCopy[2, 2];

            backFace.Cubies[2, 0] = rightFaceCubiesCopy[2, 0];
            backFace.Cubies[2, 1] = rightFaceCubiesCopy[2, 1];
            backFace.Cubies[2, 2] = rightFaceCubiesCopy[2, 2];

            leftFace.Cubies[2, 0] = backFaceCubiesCopy[2, 0];
            leftFace.Cubies[2, 1] = backFaceCubiesCopy[2, 1];
            leftFace.Cubies[2, 2] = backFaceCubiesCopy[2, 2];

            frontFace.Cubies[2, 0] = leftFaceCubiesCopy[2, 0];
            frontFace.Cubies[2, 1] = leftFaceCubiesCopy[2, 1];
            frontFace.Cubies[2, 2] = leftFaceCubiesCopy[2, 2];

        }
    }
}
