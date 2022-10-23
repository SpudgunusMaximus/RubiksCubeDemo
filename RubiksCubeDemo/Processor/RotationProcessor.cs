using RubiksCubeDemo.Constants;
using RubiksCubeDemo.Models;
using RubiksCubeDemo.Processor.Handlers;
using static RubiksCubeDemo.Models.FaceTypes;
using static RubiksCubeDemo.Models.RotationTypes;

namespace RubiksCubeDemo.Processor
{
    public interface IRotationProcessor
    {
        IEnumerable<Face> RotateFace(string rotationCommand);
        IEnumerable<Face> GetFaces(bool reset = false);
    }

    public class RotationProcessor : IRotationProcessor
    {
        private IEnumerable<Face> _faces;
        private readonly IEnumerable<IRotationHandler> _handlers;

        public RotationProcessor(IEnumerable<Face> faces, IEnumerable<IRotationHandler> handlers)
        {
            _faces = faces;
            _handlers = handlers;
        }

        public IEnumerable<Face> GetFaces(bool reset = false)
        {
            if(reset)
            {
                Reset();
            }

            return _faces;
        }

        public IEnumerable<Face> RotateFace(string rotationCommand)
        {
            var handler = GetRotationHander(rotationCommand);
            handler.Rotate();
            return _faces;
        }

        private IRotationHandler GetRotationHander(string rotationCommand) => rotationCommand switch
        {
            CommandConstants.CST_FRONT_CLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Front && h.RotationType == RotationType.Clockwise),
            CommandConstants.CST_FRONT_ANTICLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Front && h.RotationType == RotationType.AntiClockwise),
            CommandConstants.CST_RIGHT_CLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Right && h.RotationType == RotationType.Clockwise),
            CommandConstants.CST_RIGHT_ANTICLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Right && h.RotationType == RotationType.AntiClockwise),
            CommandConstants.CST_UP_CLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Up && h.RotationType == RotationType.Clockwise),
            CommandConstants.CST_UP_ANTICLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Up && h.RotationType == RotationType.AntiClockwise),
            CommandConstants.CST_BACK_CLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Back && h.RotationType == RotationType.Clockwise),
            CommandConstants.CST_BACK_ANTICLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Back && h.RotationType == RotationType.AntiClockwise),
            CommandConstants.CST_LEFT_CLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Left && h.RotationType == RotationType.Clockwise),
            CommandConstants.CST_LEFT_ANTICLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Left && h.RotationType == RotationType.AntiClockwise),
            CommandConstants.CST_DOWN_CLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Down && h.RotationType == RotationType.Clockwise),
            CommandConstants.CST_DOWN_ANTICLOCKWISE => _handlers.Single(h => h.FaceType == FaceType.Down && h.RotationType == RotationType.AntiClockwise),
            _ => throw new ArgumentOutOfRangeException(nameof(rotationCommand), $"Not expecting rotationCommand value {rotationCommand}"),           
        };

        private void Reset()
        {
            foreach(var face in _faces)
            {
                face.Reset();
            }
        }
    }
}
