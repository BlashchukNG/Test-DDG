using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Timer
{
    public class ViewTimer :
        MonoBehaviour,
        ITimerView
    {
        private const float SHOW_HIDE_DURATION = 0.3f;
        private const int ADD_SECONDS_VALUE = 60;

        [SerializeField] private Canvas _canvas;
        [SerializeField] private Button _btnMinus;
        [SerializeField] private Button _btnPlus;
        [SerializeField] private Button _btnStart;
        [SerializeField] private Button _btnClose;
        [SerializeField] private TMP_Text _txtTimer;

        private Sequence _showSequence;
        private TimerData _data;

        public bool Enabled => _canvas.enabled;

        public event Action onCloseView = () => { };

        private void Awake()
        {
            ClearView();

            _btnMinus.onClick.AddListener(Minus);
            _btnPlus.onClick.AddListener(Plus);
            _btnStart.onClick.AddListener(StartTimer);
            _btnClose.onClick.AddListener(() => onCloseView.Invoke());
        }

        private void Minus()
        {
            _data.time -= ADD_SECONDS_VALUE;
            if (_data.time < 0) _data.time = 0;

            UpdateTimer(TimerHelper.GetTimeString((int)_data.time));
        }

        private void Plus()
        {
            _data.time += ADD_SECONDS_VALUE;

            UpdateTimer(TimerHelper.GetTimeString((int)_data.time));
        }

        private void StartTimer()
        {
            _data.enabled = true;
            SetButtonsInteractable(false);
        }

        public void SetSettings(TimerData data)
        {
            _data = data;
            SetButtonsInteractable(!_data.enabled);
            UpdateTimer(TimerHelper.GetTimeString((int)_data.time));
        }

        private void SetButtonsInteractable(bool flag)
        {
            _btnMinus.interactable = flag;
            _btnPlus.interactable = flag;
            _btnStart.interactable = flag;
        }

        public void UpdateTimer(string msg)
        {
            _txtTimer.text = msg;
        }

        public void Show()
        {
            if (_showSequence == null) CreateShowAnimation();


            _showSequence.Restart();
            _showSequence.Play();
        }

        public void Hide()
        {
            _showSequence.PlayBackwards();
        }

        private void CreateShowAnimation()
        {
            _showSequence = DOTween.Sequence()
                                   .SetLink(gameObject);

            _showSequence.AppendCallback(() => _canvas.enabled = true);

            foreach (var image in transform.GetComponentsInChildren<Image>())
                _showSequence.Join(image.DOColor(Color.white, SHOW_HIDE_DURATION));
            foreach (var text in transform.GetComponentsInChildren<TMP_Text>())
                _showSequence.Join(text.DOColor(Color.white, SHOW_HIDE_DURATION));
            foreach (var image in transform.GetComponentsInChildren<RawImage>())
                _showSequence.Join(image.DOColor(Color.white, SHOW_HIDE_DURATION));
        }

        private void ClearView()
        {
            foreach (var image in transform.GetComponentsInChildren<Image>())
                image.color = Color.clear;
            foreach (var text in transform.GetComponentsInChildren<TMP_Text>())
                text.color = Color.clear;
            foreach (var image in transform.GetComponentsInChildren<RawImage>())
                image.color = Color.clear;

            _canvas.enabled = false;
        }
    }
}