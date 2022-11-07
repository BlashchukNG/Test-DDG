using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Menu
{
    public class ViewMenu :
        MonoBehaviour,
        IMenuView
    {
        private const float SHOW_HIDE_DURATION = 0.3f;

        [SerializeField] private Canvas _canvas;
        [SerializeField] private RectTransform _rootTimers;
        [SerializeField] private Button _btnAddTimer;

        private List<Sequence> _timerButtonsSequences = new();

        public event Action onAddTimer = () => { };
        public event Action<int> onOpenTimer = id => { };

        private void Awake()
        {
            ClearView();

            _btnAddTimer.onClick.AddListener(() => onAddTimer.Invoke());
        }

        public void Show()
        {
            _canvas.enabled = true;

            var seq = DOTween.Sequence()
                             .SetLink(gameObject);

            foreach (var image in transform.GetComponentsInChildren<Image>())
                seq.Join(image.DOColor(Color.white, SHOW_HIDE_DURATION));
            foreach (var text in transform.GetComponentsInChildren<TMP_Text>())
                seq.Join(text.DOColor(Color.white, SHOW_HIDE_DURATION));

            seq.AppendCallback(ShowSequenceComplete);
        }

        public void Hide()
        {
            var seq = DOTween.Sequence()
                             .SetLink(gameObject);

            foreach (var image in transform.GetComponentsInChildren<Image>())
                seq.Join(image.DOColor(Color.clear, SHOW_HIDE_DURATION));
            foreach (var text in transform.GetComponentsInChildren<TMP_Text>())
                seq.Join(text.DOColor(Color.clear, SHOW_HIDE_DURATION));

            foreach (var sequence in _timerButtonsSequences)
            {
                sequence.Restart();
                sequence.Pause();
            }
        }

        public TMP_Text AddTimer(Button prefab, int id)
        {
            var button = Instantiate(prefab, _rootTimers);

            button.image.color = Color.clear;

            var rect = button.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(-1500, -100 - id * 200);

            var text = button.GetComponentInChildren<TMP_Text>();
            text.color = Color.clear;
            text.text = "00:00:00";

            var duration = 0.5f;
            var sequence = DOTween.Sequence()
                                  .SetLink(button.gameObject)
                                  .Append(rect.DOLocalMoveX(0, duration))
                                  .Join(button.image.DOColor(Color.white, duration))
                                  .Join(text.DOColor(Color.white, duration));

            _timerButtonsSequences.Add(sequence);

            button.onClick.AddListener(() => onOpenTimer.Invoke(id));

            return text;
        }

        private void ShowSequenceComplete()
        {
            var seq = DOTween.Sequence()
                             .SetLink(gameObject);

            foreach (var sequence in _timerButtonsSequences)
            {
                seq.AppendCallback(() => sequence.Play())
                   .AppendInterval(0.3f);
            }
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