using Code.Main.Interfaces;
using Code.UI.Main;

namespace Code.UI
{
    public sealed class UIController :
        IController
    {
        private readonly UIData _data;
        private readonly IMainView _view;

        public UIController(UIData data, IMainView view)
        {
            _data = data;
            _view = view;
            
            
        }
    }
}