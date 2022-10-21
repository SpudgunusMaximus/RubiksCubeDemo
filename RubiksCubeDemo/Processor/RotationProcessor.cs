using RubiksCubeDemo.Processor.Handlers;
using static RubiksCubeDemo.FaceTypes;

namespace RubiksCubeDemo.Processor
{
    internal class RotationProcessor
    {
        private List<Face> _faces;

        public RotationProcessor(List<Face> faces)
        {
            _faces = faces;
        }

        public void RotateFace(FaceType faceType)
        {
            var faceToRate = _faces.Single(f => f.FaceType == faceType);
            WriteToConsole(faceToRate, "BEFORE:");
            Transpose(faceToRate, false);
            //WriteToConsole(faceToRate, "MID:");
            SwapColumns(faceToRate);
            WriteToConsole(faceToRate, "AFTER:");

            FrontClockwiseHandler handler = new FrontClockwiseHandler(_faces);
            handler.MoveNeighbours();
            //Console.WriteLine("And Again...");
            //handler.MoveNeighbours();
        }

        private void Transpose(Face face, bool clockwise)
        {
            int maxIndex = face.ColLength - 1;
            // Transpose the matrix
            if (clockwise)
            {
                for (int i = 0; i <= maxIndex; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        int temp = face.Cubies[i, j];
                        face.Cubies[i, j] = face.Cubies[j, i];
                        face.Cubies[j, i] = temp;
                    }
                }
            }
            else
            {
                for(int i = 0; i < maxIndex; i++)
                {
                    for (int j = 0; j < maxIndex; j++)
                    {
                        int temp = face.Cubies[i, j];
                        face.Cubies[i, j] = face.Cubies[maxIndex - j, maxIndex - i];
                        face.Cubies[maxIndex - j, maxIndex - i] = temp;
                    }
                }
            }

        }

        private void SwapColumns(Face face)
        {
            for (int row = 0; row < face.RowLength; row++)
            {
                var temp = face.Cubies[row, 0];
                face.Cubies[row, 0] = face.Cubies[row, face.RowLength - 1];
                face.Cubies[row, face.RowLength - 1] = temp;
            }
        }

        private void WriteToConsole(Face face, string prefix)
        {
            Console.WriteLine(face.ToString());
        }
    }
}
