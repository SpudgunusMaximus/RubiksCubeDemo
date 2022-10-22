using RubiksCubeDemo.Processor.Handlers;
using static RubiksCubeDemo.FaceTypes;
using static RubiksCubeDemo.RotationTypes;

namespace RubiksCubeDemo.Processor
{
    public interface IRotationProcessor
    {
        List<Face> RotateFace(string rotationCommand);
    }

    public class RotationProcessor : IRotationProcessor
    {
        private List<Face> _faces;
        private readonly IEnumerable<IRotationHandler> _handlers;

        public RotationProcessor(List<Face> faces, IEnumerable<IRotationHandler> handlers)
        {
            _faces = faces;
            _handlers = handlers;
        }

        public List<Face> RotateFace(string rotationCommand)
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
    }
}
