using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RubiksCubeDemo.FaceTypes;

namespace RubiksCubeDemo.Processor.Handlers
{
    internal class FrontClockwiseHandler
    {
        private readonly List<Face> _faces;

        public FrontClockwiseHandler(List<Face> faces)
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

            rightFace.Cubies[0, 0] = upFaceCubiesCopy[2, 0];
            rightFace.Cubies[1, 0] = upFaceCubiesCopy[2, 1];
            rightFace.Cubies[2, 0] = upFaceCubiesCopy[2, 2];

            downFace.Cubies[0, 2] = rightFaceCubiesCopy[0, 0];
            downFace.Cubies[0, 1] = rightFaceCubiesCopy[1, 0];
            downFace.Cubies[0, 0] = rightFaceCubiesCopy[2, 0];

            leftFace.Cubies[2, 2] = downFaceCubiesCopy[0, 2];
            leftFace.Cubies[1, 2] = downFaceCubiesCopy[0, 1];
            leftFace.Cubies[0, 2] = downFaceCubiesCopy[0, 0];

            upFace.Cubies[2, 0] = leftFaceCubiesCopy[2, 2];
            upFace.Cubies[2, 1] = leftFaceCubiesCopy[1, 2];
            upFace.Cubies[2, 2] = leftFaceCubiesCopy[0, 2];

            WriteToConsole(upFace, rightFace, downFace, leftFace);

        }

        private void WriteToConsole(Face upFace, Face rightFace, Face downFace, Face leftFace)
        {
            Console.WriteLine(nameof(upFace));
            Console.WriteLine(upFace);
            Console.WriteLine(nameof(rightFace));
            Console.WriteLine(rightFace);
            Console.WriteLine(nameof(downFace));
            Console.WriteLine(downFace);
            Console.WriteLine(nameof(leftFace));
            Console.WriteLine(leftFace);
        }
    }
}
