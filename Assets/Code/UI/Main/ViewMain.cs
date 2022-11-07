using Code.UI.Menu;
using Code.UI.Timer;
using UnityEngine;

namespace Code.UI.Main
{
    public sealed class ViewMain :
        MonoBehaviour,
        IMainView
    {
        [SerializeField] private ViewMenu _viewMenu;
        [SerializeField] private ViewTimer _viewTimer;

        public ViewMenu ViewMenu => _viewMenu;
        public ViewTimer ViewTimer => _viewTimer;
    }
}