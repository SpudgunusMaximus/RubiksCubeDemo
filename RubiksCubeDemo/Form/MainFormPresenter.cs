using RubiksCubeDemo.Processor;

namespace RubiksCubeDemo
{
    public class MainFormPresenter
    {
        private readonly IMainFormView _view;
        private readonly IRotationProcessor _rotationProcessor;

        public MainFormPresenter(IRotationProcessor rotationProcessor, IMainFormView view)
        {
            _rotationProcessor = rotationProcessor;
            _view = view;
            Initialise();
        }

        public void Initialise()
        {
            _view.SetFaces = _rotationProcessor.GetFaces();
        }

        public void MakeMove(string move)
        {
            _view.SetFaces = _rotationProcessor.RotateFace(move);
            _view.AddToHistory(move);
        }

        public void Reset()
        {
            _view.SetFaces = _rotationProcessor.GetFaces(true);
            _view.ClearHistory();
        }
    }
}
