using System;
using Code.UI.Interfaces;
using UnityEngine.UI;

namespace Code.UI.Menu
{
    public interface IMenuView :
        IView
    {
        event Action onAddTimer;
        event Action<int> onOpenTimer;
        void AddTimer(Button prefab, int id);
    }
}