using RubiksCubeDemo.Processor;
using System.Drawing;

namespace RubiksCubeDemo
{
    public partial class MainForm : Form
    {
        private readonly List<Face> _faces;
        private readonly SolidBrush[] _brushes;
        private readonly Pen _pen;

        private readonly IRotationProcessor _rotationProcessor;

        public MainForm(List<Face> faces, IRotationProcessor rotationProcessor)
        {
            InitializeComponent();
            _faces = faces;
            _rotationProcessor = rotationProcessor;

            _pen = new Pen(Color.Black);

            _brushes = new SolidBrush[]
            {
                new SolidBrush(Color.Green),
                new SolidBrush(Color.Orange),
                new SolidBrush(Color.Red),
                new SolidBrush(Color.Blue),
                new SolidBrush(Color.White),
                new SolidBrush(Color.Yellow)
            };
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = panel1.CreateGraphics();
            //Pen p = new Pen(Color.Black);

            var frontFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Front);
            var leftFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Left);
            var rightFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Right);
            var upFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Up);
            var backFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Back);
            var downFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Down);

            //SolidBrush textBrush = new SolidBrush(Color.Black);

            DrawFace(frontFace, 200, 150, gfx);
            DrawFace(leftFace, 110, 150, gfx);
            DrawFace(rightFace, 290, 150, gfx);
            DrawFace(backFace, 380, 150, gfx);
            DrawFace(upFace, 200, 60, gfx);
            DrawFace(downFace, 200, 240, gfx);
        }

        private void DrawFace(Face face, int x, int y, Graphics gfx)
        {
            for (int i = 0; i < face.ColLength; i++)
            {
                for (int j = 0; j < face.RowLength; j++)
                {
                    SolidBrush br = _brushes.Single(c => c.Color == face.Cubies[i, j]);
                    gfx.FillRectangle(br, x + (i * 30), y + (j * 30), 30, 30);
                    gfx.DrawRectangle(_pen, x + (i * 30), y + (j * 30), 30, 30);
                    //gfx.DrawString($"{i},{j}", DefaultFont, textBrush, new PointF((float)frontStartX + ((float)i * 30), (float)frontStartY + ((float)j * 30)));
                }
            }
        }

        #region EVENT HANDLERS

        private void btn_FrontClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_FRONT_CLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_FrontAntiClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_FRONT_ANTICLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_RightClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_RIGHT_CLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_RightAntiClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_RIGHT_ANTICLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_UpClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_UP_CLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_UpAntiClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_UP_ANTICLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_BackClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_BACK_CLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_BackAntiClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_BACK_ANTICLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_LeftClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_LEFT_CLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_LeftAntiClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_LEFT_ANTICLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_DownClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_DOWN_CLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_DownAntiClockwise_Click(object sender, EventArgs e)
        {
            _rotationProcessor.RotateFace(CommandConstants.CST_DOWN_ANTICLOCKWISE);
            panel1.Invalidate();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            _rotationProcessor.Reset();
            panel1.Invalidate();
        }

        #endregion
    }
}
