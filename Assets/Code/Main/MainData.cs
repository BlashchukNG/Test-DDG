using System;
using Code.UI;
using UnityEngine;

namespace Code.Main
{
    [CreateAssetMenu(fileName = "data main", menuName = "GAME DATA/Main", order = 0)]
    public sealed class MainData :
        ScriptableObject
    {
        public int targetFrameRate = 60;

        [SerializeField] private string _ui = "Data/data ui";

        public UIData UIData => Load<UIData>(_ui);


        private T Load<T>(string path)
            where T : ScriptableObject
        {
            var file = Resources.Load<T>(path);
            if (file == null) throw new NullReferenceException($"file not fount in path: Resources/{path}");
            return file;
        }
    }

}