using RubiksCubeDemo.Constants;
using RubiksCubeDemo.Models;
using RubiksCubeDemo.Processor;
using System.Drawing;

namespace RubiksCubeDemo
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly SolidBrush[] _brushes;
        private readonly Pen _pen;
        private List<Face>? _faces;

        private readonly MainFormPresenter _presenter;

        public List<Face> SetFaces
        {
            set
            {
                _faces = value;
                panel1.Invalidate();
            }
        }

        public MainForm(IRotationProcessor rotationProcessor)
        {
            InitializeComponent();
            _presenter = new MainFormPresenter(rotationProcessor, this);

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

        public void MakeMove(string move)
        {
            _presenter.MakeMove(move);
        }

        public void ClearHistory()
        {
            lst_MoveHistory.Items.Clear();
        }

        public void AddToHistory(string move)
        {
            lst_MoveHistory.Items.Add(move);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = panel1.CreateGraphics();

            var frontFace = _faces!.Single(f => f.FaceType == FaceTypes.FaceType.Front);
            var leftFace = _faces!.Single(f => f.FaceType == FaceTypes.FaceType.Left);
            var rightFace = _faces!.Single(f => f.FaceType == FaceTypes.FaceType.Right);
            var upFace = _faces!.Single(f => f.FaceType == FaceTypes.FaceType.Up);
            var backFace = _faces!.Single(f => f.FaceType == FaceTypes.FaceType.Back);
            var downFace = _faces!.Single(f => f.FaceType == FaceTypes.FaceType.Down);

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
                }
            }
        }

        #region EVENT HANDLERS

        private void btn_FrontClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_FRONT_CLOCKWISE);
        }

        private void btn_FrontAntiClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_FRONT_ANTICLOCKWISE);
        }

        private void btn_RightClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_RIGHT_CLOCKWISE);
        }

        private void btn_RightAntiClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_RIGHT_ANTICLOCKWISE);
        }

        private void btn_UpClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_UP_CLOCKWISE);
        }

        private void btn_UpAntiClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_UP_ANTICLOCKWISE);
        }

        private void btn_BackClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_BACK_CLOCKWISE);
        }

        private void btn_BackAntiClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_BACK_ANTICLOCKWISE);
        }

        private void btn_LeftClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_LEFT_CLOCKWISE);
        }

        private void btn_LeftAntiClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_LEFT_ANTICLOCKWISE);
        }

        private void btn_DownClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_DOWN_CLOCKWISE);
        }

        private void btn_DownAntiClockwise_Click(object sender, EventArgs e)
        {
            _presenter.MakeMove(CommandConstants.CST_DOWN_ANTICLOCKWISE);
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            _presenter.Reset();
        }

        #endregion
    }
}
