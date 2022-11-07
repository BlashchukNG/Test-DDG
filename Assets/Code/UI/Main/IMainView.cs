using Code.UI.Menu;
using Code.UI.Timer;

namespace Code.UI.Main
{
    public interface IMainView
    {
        ViewMenu ViewMenu { get; }
        ViewTimer ViewTimer { get; }
    }
}