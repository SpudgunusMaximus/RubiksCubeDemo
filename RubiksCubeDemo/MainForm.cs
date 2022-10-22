using RubiksCubeDemo.Processor;

namespace RubiksCubeDemo
{
    public partial class MainForm : Form
    {
        private readonly List<Face> _faces;
        private readonly IRotationProcessor _rotationProcessor;

        public MainForm(List<Face> faces, IRotationProcessor rotationProcessor)
        {
            InitializeComponent();
            _faces = faces;
            _rotationProcessor = rotationProcessor;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black);

            var frontFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Front);
            var leftFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Left);
            var rightFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Right);
            var upFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Up);
            var backFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Back);
            var downFace = _faces.Single(f => f.FaceType == FaceTypes.FaceType.Down);

            SolidBrush[] solidBrushes = new SolidBrush[]
            {
                new SolidBrush(Color.Green),
                new SolidBrush(Color.Orange),
                new SolidBrush(Color.Red),
                new SolidBrush(Color.Blue),
                new SolidBrush(Color.White),
                new SolidBrush(Color.Yellow)
            };

            SolidBrush textBrush = new SolidBrush(Color.Black);

            int frontStartX = 200;
            int frontStartY = 150;

            for(int i = 0; i < frontFace.ColLength; i++)
            {
                for(int j = 0; j < frontFace.RowLength; j++)
                {
                    SolidBrush br = solidBrushes.Single(c => c.Color == frontFace.Cubies[i, j]);
                    g.FillRectangle(br, frontStartX + (i * 30), frontStartY + (j * 30), 30, 30);
                    g.DrawRectangle(p, frontStartX + (i * 30), frontStartY + (j * 30), 30, 30);
                    g.DrawString($"{i},{j}", DefaultFont, textBrush, new PointF((float) frontStartX + ((float)i * 30),(float)frontStartY + ((float)j * 30)));
                }
            }            
            
            int leftStartX = 110;
            int leftStartY = 150;

            for (int i = 0; i < leftFace.ColLength; i++)
            {
                for (int j = 0; j < leftFace.RowLength; j++)
                {
                    SolidBrush br = solidBrushes.Single(c => c.Color == leftFace.Cubies[i, j]);
                    g.FillRectangle(br, leftStartX + (i * 30), leftStartY + (j * 30), 30, 30);
                    g.DrawRectangle(p, leftStartX + (i * 30), leftStartY + (j * 30), 30, 30);
                    g.DrawString($"{i},{j}", DefaultFont, textBrush, new PointF((float)leftStartX + ((float)i * 30), (float)leftStartY + ((float)j * 30)));
                }
            }

            int rightStartX = 290;
            int rightStartY = 150;

            for(int i = 0; i < rightFace.ColLength; i++)
            {
                for(int j = 0; j < rightFace.RowLength; j++)
                {
                    SolidBrush br = solidBrushes.Single(c => c.Color == rightFace.Cubies[i, j]);
                    g.FillRectangle(br, rightStartX + (i * 30), rightStartY + (j * 30), 30, 30);
                    g.DrawRectangle(p, rightStartX + (i * 30), rightStartY + (j * 30), 30, 30);
                    g.DrawString($"{i},{j}", DefaultFont, textBrush, new PointF((float)rightStartX + ((float)i * 30), (float)rightStartY + ((float)j * 30)));
                }
            }
            
            int backStartX = 380;
            int backStartY = 150;

            for(int i = 0; i < backFace.ColLength; i++)
            {
                for(int j = 0; j < backFace.RowLength; j++)
                {
                    SolidBrush br = solidBrushes.Single(c => c.Color == backFace.Cubies[i, j]);
                    g.FillRectangle(br, backStartX + (i * 30), backStartY + (j * 30), 30, 30);
                    g.DrawRectangle(p, backStartX + (i * 30), backStartY + (j * 30), 30, 30);
                    g.DrawString($"{i},{j}", DefaultFont, textBrush, new PointF((float)backStartX + ((float)i * 30), (float)backStartY + ((float)j * 30)));
                }
            }                  
            
            int upStartX = 200;
            int upStartY = 60;

            for(int i = 0; i < upFace.ColLength; i++)
            {
                for(int j = 0; j < upFace.RowLength; j++)
                {
                    SolidBrush br = solidBrushes.Single(c => c.Color == upFace.Cubies[i, j]);
                    g.FillRectangle(br, upStartX + (i * 30), upStartY + (j * 30), 30, 30);
                    g.DrawRectangle(p, upStartX + (i * 30), upStartY + (j * 30), 30, 30);
                    g.DrawString($"{i},{j}", DefaultFont, textBrush, new PointF((float)upStartX + ((float)i * 30), (float)upStartY + ((float)j * 30)));
                }
            }              
            
            int downStartX = 200;
            int downStartY = 240;

            for(int i = 0; i < downFace.ColLength; i++)
            {
                for(int j = 0; j < downFace.RowLength; j++)
                {
                    SolidBrush br = solidBrushes.Single(c => c.Color == downFace.Cubies[i, j]);
                    g.FillRectangle(br, downStartX + (i * 30), downStartY + (j * 30), 30, 30);
                    g.DrawRectangle(p, downStartX + (i * 30), downStartY + (j * 30), 30, 30);
                    g.DrawString($"{i},{j}", DefaultFont, textBrush, new PointF((float)downStartX + ((float)i * 30), (float)downStartY + ((float)j * 30)));
                }
            }        
        }

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
    }
}
