
using RubiksCubeDemo.Models;

namespace RubiksCubeDemo
{
    public interface IMainFormView
    {
        List<Face> SetFaces { set; }
        void MakeMove(string move);
        void AddToHistory(string move);
        void ClearHistory();
    }
}
