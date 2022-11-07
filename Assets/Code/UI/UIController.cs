using System.Collections.Generic;
using Code.Main.Interfaces;
using Code.UI.Main;
using TMPro;

namespace Code.UI
{
    public sealed class UIController :
        IController,
        ITick
    {
        private readonly UIData _data;
        private readonly IMainView _view;
        private readonly List<TimerData> _timers = new();

        private readonly int _maxTimers = 8;

        private int _timersCount;
        private int _currentTimer;

        public UIController(UIData data, IMainView view)
        {
            _data = data;
            _view = view;

            _view.ViewMenu.onAddTimer += AddTimer;
            _view.ViewMenu.onOpenTimer += ShowTimer;

            _view.ViewTimer.onCloseView += CloseTimerView;

            _view.ViewMenu.Show();
        }

        private void CloseTimerView()
        {
            _view.ViewTimer.Hide();
            _view.ViewMenu.Show();
        }

        private void AddTimer()
        {
            _timersCount++;

            if (_timersCount > _maxTimers) return;

            var data = new TimerData
            {
                text = _view.ViewMenu.AddTimer(_data.prefabMenuButton, _timersCount - 1)
            };

            _timers.Add(data);
        }

        private void ShowTimer(int id)
        {
            _currentTimer = id;

            _view.ViewMenu.Hide();
            _view.ViewTimer.SetSettings(_timers[_currentTimer]);
            _view.ViewTimer.Show();
        }

        public void Tick(float delta)
        {
            foreach (var timer in _timers)
            {
                if (!timer.enabled) continue;

                timer.time -= delta;
                if (timer.time < 0)
                {
                    timer.enabled = false;
                    timer.time = 0;
                }

                timer.text.text = TimerHelper.GetTimeString((int)timer.time);
            }

            if (_view.ViewTimer.Enabled && _timers[_currentTimer].enabled)
            {
                _view.ViewTimer.UpdateTimer(TimerHelper.GetTimeString((int)_timers[_currentTimer].time));
            }
        }
    }
}