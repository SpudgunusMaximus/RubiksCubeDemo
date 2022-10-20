using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RubiksCubeDemo.FaceTypes;

namespace RubiksCubeDemo
{
    internal class Face
    {
        public int[,] Cubies { get; set; }
        public FaceType FaceType { get; }

        public Face(FaceType faceType)
        {
            FaceType = faceType;

            Cubies = new int[3, 3]
            {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9}
            };
        }

        public int RowLength => Cubies.GetLength(0);
        public int ColLength => Cubies.GetLength(1);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int col = 0; col < ColLength; col++)
            {
                for (int row = 0; row < RowLength; row++)
                {
                    sb.Append(Cubies[col, row] + " ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
