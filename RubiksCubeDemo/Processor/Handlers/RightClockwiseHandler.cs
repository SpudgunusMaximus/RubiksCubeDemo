using static RubiksCubeDemo.FaceTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class RightAntiClockwiseHandler
    {
        private readonly List<Face> _faces;

        public RightAntiClockwiseHandler(List<Face> faces)
        {
            _faces = faces;
        }

        public void MoveNeighbours()
        {
            Face upFace = _faces.Single(f => f.FaceType == FaceType.Up);
            Face frontFace = _faces.Single(f => f.FaceType == FaceType.Front);
            Face downFace = _faces.Single(f => f.FaceType == FaceType.Down);
            Face backFace = _faces.Single(f => f.FaceType == FaceType.Back);

            var frontFaceCubiesCopy = (int[,])frontFace.Cubies.Clone();
            var backFaceCubiesCopy = (int[,])backFace.Cubies.Clone();
            var downFaceCubiesCopy = (int[,])downFace.Cubies.Clone();
            var upFaceCubiesCopy = (int[,])upFace.Cubies.Clone();

            backFace.Cubies[0, 0] = downFaceCubiesCopy[2, 2];
            backFace.Cubies[1, 0] = downFaceCubiesCopy[1, 2];
            backFace.Cubies[2, 0] = downFaceCubiesCopy[0, 2];

            downFace.Cubies[2, 2] = frontFaceCubiesCopy[2, 2];
            downFace.Cubies[1, 2] = frontFaceCubiesCopy[1, 2];
            downFace.Cubies[0, 2] = frontFaceCubiesCopy[0, 2];

            frontFace.Cubies[2, 2] = upFaceCubiesCopy[2, 2];
            frontFace.Cubies[1, 2] = upFaceCubiesCopy[1, 2];
            frontFace.Cubies[0, 2] = upFaceCubiesCopy[0, 2];

            upFace.Cubies[2, 2] = backFaceCubiesCopy[0, 0];
            upFace.Cubies[1, 2] = backFaceCubiesCopy[1, 0];
            upFace.Cubies[0, 2] = backFaceCubiesCopy[2, 0];

        }
    }
}
