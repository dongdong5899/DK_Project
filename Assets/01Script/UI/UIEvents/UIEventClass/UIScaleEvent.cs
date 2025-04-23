using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.UI.Events
{
    public class UIScaleEvent : UIEvent
    {
        [SerializeField] private Vector3 _targetScale;
        [SerializeField] private float _duration;
        [SerializeField] private AnimationCurve _curve;

        private static Dictionary<MonoUI, Tween> _TweenDictionary = new();

        public override void EventPlay()
        {
            if (_TweenDictionary.TryGetValue(_monoUI, out Tween tween) &&
                tween != null && tween.IsActive())
                tween.Kill();
            _TweenDictionary[_monoUI] = _monoUI.transform.DOScale(_targetScale, _duration).SetEase(_curve);
        }
    }
}
