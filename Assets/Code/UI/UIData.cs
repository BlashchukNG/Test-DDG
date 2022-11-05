using Code.UI.Main;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    [CreateAssetMenu(fileName = "data ui", menuName = "GAME DATA/UI", order = 0)]
    public sealed class UIData :
        ScriptableObject
    {
        public ViewMain prefabMainView;
        public Button prefabMenuButton;
    }
}