using static RubiksCubeDemo.FaceTypes;
using static RubiksCubeDemo.RotationTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    public abstract class RotationHandlerBase
    {
        protected readonly List<Face> _faces;
        public RotationType RotationType { get; }
        public FaceType FaceType { get; } 
         
        private readonly Face _rotationFace;
        public RotationHandlerBase(List<Face> faces, FaceType faceType, RotationType rotationType)
        {
            _faces = faces;
            _rotationFace = faces.Single(f => f.FaceType == faceType);
            RotationType = rotationType;
            FaceType = faceType;
        }

        protected void Transpose()
        {
            // Transpose the matrix

            int maxIndex = _rotationFace!.ColLength - 1;

            if (RotationType == RotationType.AntiClockwise)
            {
                for (int i = 0; i <= maxIndex; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        var temp = _rotationFace.Cubies[i, j];
                        _rotationFace.Cubies[i, j] = _rotationFace.Cubies[j, i];
                        _rotationFace.Cubies[j, i] = temp;
                    }
                }
            }
            else
            {
                for (int i = 0; i < maxIndex; i++)
                {
                    for (int j = 0; j < maxIndex; j++)
                    {
                        var temp = _rotationFace.Cubies[i, j];
                        _rotationFace.Cubies[i, j] = _rotationFace.Cubies[maxIndex - j, maxIndex - i];
                        _rotationFace.Cubies[maxIndex - j, maxIndex - i] = temp;
                    }
                }
            }

            //swap columns
            for (int row = 0; row < _rotationFace.RowLength; row++)
            {
                var temp = _rotationFace.Cubies[row, 0];
                _rotationFace.Cubies[row, 0] = _rotationFace.Cubies[row, _rotationFace.RowLength - 1];
                _rotationFace.Cubies[row, _rotationFace.RowLength - 1] = temp;
            }
        }

        protected abstract void MoveNeighbours();
    }
}
