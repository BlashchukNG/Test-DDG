using Code.Main.Interfaces;
using Code.UI;
using UnityEngine;

namespace Code.Main
{
    public sealed class MainController :
        MonoBehaviour
    {
        private const string PATH_DATA = "Data/data main";

        private MainData _data;
        private IControllers _repo;

        private void Awake()
        {
            _data = Resources.Load<MainData>(PATH_DATA);
            _repo = new Controllers();

            Application.targetFrameRate = _data.targetFrameRate;
            
            Init();
        }

        private void Init()
        {
            var ui = new UIControllerInit(_data.UIData).Create();

            _repo.Add(ui);
        }

        private void Update() => _repo.Tick(Time.deltaTime);
        private void FixedUpdate() => _repo.FixedTick(Time.fixedDeltaTime);
        private void LateUpdate() => _repo.LateTick(Time.deltaTime);
    }
}