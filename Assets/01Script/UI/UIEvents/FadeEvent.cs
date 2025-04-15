using DG.Tweening;
using UnityEngine;

namespace DKProject.UI
{
    public class FadeEvent : MonoBehaviour
    {
        public CanvasGroup canvasGroup;
        [SerializeField] private float _easingDuration;
        [SerializeField] private float _fadeInValue, _fadeOutValue;
        [SerializeField] private bool _useOpposite;

        private Tween _fadeTween;

        public void FadeIn()
        {
            if (_fadeTween != null && _fadeTween.active) 
                _fadeTween.Kill();

            _fadeTween = canvasGroup.DOFade(_fadeInValue, _easingDuration);
        }

        public void FadeOut()
        {
            if (_fadeTween != null && _fadeTween.active)
                _fadeTween.Kill();

            _fadeTween = canvasGroup.DOFade(_fadeOutValue, _easingDuration);
        }

        public void Fade(bool isFadeIn)
        {
            if (_useOpposite) isFadeIn = !isFadeIn;

            Debug.Log(isFadeIn);
            if (isFadeIn) FadeIn();
            else FadeOut();
        }
    }
}

