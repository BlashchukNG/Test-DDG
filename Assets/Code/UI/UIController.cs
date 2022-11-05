using Code.Main.Interfaces;
using Code.UI.Main;

namespace Code.UI
{
    public sealed class UIController :
        IController
    {
        private readonly UIData _data;
        private readonly IMainView _view;

        private readonly int _maxTimers = 8;

        private int _timers;

        public UIController(UIData data, IMainView view)
        {
            _data = data;
            _view = view;

            _view.ViewMenu.onAddTimer += AddTimer;
            _view.ViewMenu.onOpenTimer += ShowTimer;

            _view.ViewMenu.Show();
        }

        private void AddTimer()
        {
            _timers++;

            if (_timers > _maxTimers) return;

            _view.ViewMenu.AddTimer(_data.prefabMenuButton, _timers - 1);
        }

        private void ShowTimer(int id)
        {
        }
    }
}