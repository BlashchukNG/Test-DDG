using System;
using Code.UI.Interfaces;

namespace Code.UI.Timer
{
    public interface ITimerView :
        IView
    {
        bool Enabled { get; }
        event Action onCloseView;
        void UpdateTimer(string msg);
        void SetSettings(TimerData data);
    }
}