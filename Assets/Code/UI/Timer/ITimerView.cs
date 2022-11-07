using Code.UI.Interfaces;

namespace Code.UI.Timer
{
    public interface ITimerView :
        IView
    {
        bool Enabled { get; }
        void UpdateTimer(int time);
    }
}