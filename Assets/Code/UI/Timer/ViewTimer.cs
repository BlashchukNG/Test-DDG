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

        [SerializeField] private Canvas _canvas;
        [SerializeField] private Button btnMinus;
        [SerializeField] private Button btnPlus;
        [SerializeField] private Button btnStart;
        [SerializeField] private TMP_Text txtTimer;

        private Sequence _showSequence;

        public bool Enabled => _canvas.enabled;

        private void Awake()
        {
            ClearView();
        }

        public void UpdateTimer(int time)
        {
            var hours = time / 3600;
            var minutes = time % 3600;
            var seconds = time % 60;

            txtTimer.text = $"{hours}:{minutes}:{seconds}";
        }

        public void Show()
        {
            if (_showSequence == null) CreateShowAnimation();

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
        }


        private void ClearView()
        {
            foreach (var image in transform.GetComponentsInChildren<Image>())
                image.color = Color.clear;
            foreach (var text in transform.GetComponentsInChildren<TMP_Text>())
                text.color = Color.clear;
            _canvas.enabled = false;
        }
    }
}