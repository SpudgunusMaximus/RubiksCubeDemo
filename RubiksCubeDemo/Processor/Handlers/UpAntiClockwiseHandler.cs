using static RubiksCubeDemo.FaceTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class UpClockwiseHandler
    {
        private readonly List<Face> _faces;

        public UpClockwiseHandler(List<Face> faces)
        {
            _faces = faces;
        }

        public void MoveNeighbours()
        {
            Face frontFace = _faces.Single(f => f.FaceType == FaceType.Front);
            Face backFace = _faces.Single(f => f.FaceType == FaceType.Back);
            Face leftFace = _faces.Single(f => f.FaceType == FaceType.Left);
            Face rightFace = _faces.Single(f => f.FaceType == FaceType.Right);

            var frontFaceCubiesCopy = (int[,])frontFace.Cubies.Clone();
            var backFaceCubiesCopy = (int[,])backFace.Cubies.Clone();
            var leftFaceCubiesCopy = (int[,])leftFace.Cubies.Clone();
            var rightFaceCubiesCopy = (int[,])rightFace.Cubies.Clone();

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
