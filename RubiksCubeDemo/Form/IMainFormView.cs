
using RubiksCubeDemo.Models;

namespace RubiksCubeDemo
{
    public interface IMainFormView
    {
        IEnumerable<Face> SetFaces { set; }
        void MakeMove(string move);
        void AddToHistory(string move);
        void ClearHistory();
    }
}
