using DG.Tweening;
using DKProject.UI.Events;
using UnityEngine;

namespace DKProject.UI
{
    public class FadeEvent : ToggleEvent
    {
        public CanvasGroup canvasGroup;
        [SerializeField] private float _easingDuration;
        [SerializeField] private float _fadeInValue, _fadeOutValue;
        [SerializeField] private bool _useOpposite;

        private Tween _fadeTween;

        public void FadeIn()
        {
        }

        public void FadeOut()
        {
        }

        public void Fade(bool isFadeIn)
        {
            if (_useOpposite) isFadeIn = !isFadeIn;

            Debug.Log(isFadeIn);
            if (isFadeIn) FadeIn();
            else FadeOut();
        }

        public override void Enable()
        {
            if (_fadeTween != null && _fadeTween.active)
                _fadeTween.Kill();

            _fadeTween = canvasGroup.DOFade(_fadeInValue, _easingDuration);
        }

        public override void Disable()
        {
            if (_fadeTween != null && _fadeTween.active)
                _fadeTween.Kill();

            _fadeTween = canvasGroup.DOFade(_fadeOutValue, _easingDuration);
        }
    }
}

