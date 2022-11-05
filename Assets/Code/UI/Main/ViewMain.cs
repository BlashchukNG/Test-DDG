using Code.UI.Menu;
using UnityEngine;

namespace Code.UI.Main
{
    public sealed class ViewMain :
        MonoBehaviour,
        IMainView
    {
        [SerializeField] private ViewMenu _viewMenu;

        public ViewMenu ViewMenu => _viewMenu;
    }
}