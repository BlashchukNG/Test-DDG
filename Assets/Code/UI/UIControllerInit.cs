using Code.Main.Interfaces;
using UnityEngine;

namespace Code.UI
{
    public sealed class UIControllerInit
    {
        private UIData _data;

        public UIControllerInit(UIData data)
        {
            _data = data;
        }

        public IController Create()
        {
            var view = Object.Instantiate(_data.prefabMainView);
            
            return new UIController(_data, view);
        }
    }
}