using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.UI.Events
{
    public class UISizeEvent : UIEvent
    {
        [SerializeField] private Vector2 _targetSize;
        [SerializeField] private float _duration;
        [SerializeField] private AnimationCurve _curve;

        private static Dictionary<MonoUI, Tween> _TweenDictionary = new();

        public override void EventPlay()
        {
            if (_TweenDictionary.TryGetValue(_monoUI, out Tween tween) &&
                tween != null && tween.IsActive())
                tween.Kill();
            _TweenDictionary[_monoUI] = _monoUI.RectTransform.DOSizeDelta(_targetSize, _duration).SetEase(_curve);
        }
    }
}
