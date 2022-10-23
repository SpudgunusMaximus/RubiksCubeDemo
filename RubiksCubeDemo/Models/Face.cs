using System.Text;
using static RubiksCubeDemo.Models.FaceTypes;

namespace RubiksCubeDemo.Models
{
    public class Face
    {
        public Color[,] Cubies { get; set; }
        public FaceType FaceType { get; }

        public Face(FaceType faceType)
        {
            FaceType = faceType;
            var colour = GetColor(faceType);

            Cubies = new Color[3, 3]
            {
                { colour, colour, colour},
                { colour, colour, colour},
                { colour, colour, colour}
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

        public void Reset()
        {
            Color color = GetColor(FaceType);
            for (int col = 0; col < ColLength; col++)
            {
                for (int row = 0; row < RowLength; row++)
                {
                    Cubies[col, row] = color;
                }
            }
        }

        private Color GetColor(FaceType faceType) => faceType switch
        {
            FaceType.Front => Color.Green,
            FaceType.Right => Color.Red,
            FaceType.Up => Color.White,
            FaceType.Back => Color.Blue,
            FaceType.Left => Color.Orange,
            FaceType.Down => Color.Yellow,
            _ => throw new ArgumentOutOfRangeException(nameof(faceType), $"Not expecting enum type {faceType}"),
        };
    }
}
