using System;
using Code.UI.Interfaces;
using TMPro;
using UnityEngine.UI;

namespace Code.UI.Menu
{
    public interface IMenuView :
        IView
    {
        event Action onAddTimer;
        event Action<int> onOpenTimer;
        TMP_Text AddTimer(Button prefab, int id);
    }
}