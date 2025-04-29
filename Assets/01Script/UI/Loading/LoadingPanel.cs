using DG.Tweening;
using DKProject.Core;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DKProject.UI
{
    public class LoadingPanel : ToggleUI
    {
        public override string Key => "LoadingPanel";

        [SerializeField] private float _duration = 0.2f;
        [SerializeField] private AnimationCurve _easing;
        [SerializeField] private TextMeshProUGUI _loadingText;
        [SerializeField] private List<string> _loadingTextList;

        private Tween _toggleTween;

        public override void Open()
        {
            _loadingText.SetText(RandomUtility.GetRandomElement<string>(_loadingTextList)); 

            if (_toggleTween != null && _toggleTween.active)
                _toggleTween.Kill();

            _toggleTween = RectTransform.DOAnchorPosY(0, _duration).SetEase(_easing)
                .OnComplete(() => onCompleteOpen?.Invoke());
        }

        public override void Close()
        {
            if (_toggleTween != null && _toggleTween.active)
                _toggleTween.Kill();

            _toggleTween = RectTransform.DOAnchorPosY(RectTransform.rect.height, _duration)
                .OnComplete(() => onCompleteClose?.Invoke());
        }
    }
}
