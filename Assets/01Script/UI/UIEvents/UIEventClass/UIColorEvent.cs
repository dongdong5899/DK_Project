using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI.Events
{
    public class UIColorEvent : UIEvent
    {
        [SerializeField] private List<Image> _targetImage;
        [SerializeField] private List<TMP_Text> _targetText;
        [SerializeField] private Color _color;
        [SerializeField] private float _duration;
        [SerializeField] private AnimationCurve _curve;

        private static Dictionary<Image, Tween> _ImageTweenDictionary = new();
        private static Dictionary<TMP_Text, Tween> _TextTweenDictionary = new();

        public override void EventInit(MonoUI monoUI)
        {
            base.EventInit(monoUI);
        }

        public override void EventPlay()
        {
            _targetImage?.ForEach(image =>
            {
                if (_ImageTweenDictionary.TryGetValue(image, out Tween tween) && tween != null && tween.IsActive())
                    tween.Kill();
                _ImageTweenDictionary[image] = image.DOColor(_color, _duration).SetEase(_curve).SetId($"{image.GetInstanceID()}Color");
            });
            _targetText?.ForEach(text =>
            {
                if (_TextTweenDictionary.TryGetValue(text, out Tween tween) && tween != null && tween.IsActive())
                    tween.Kill();
                _TextTweenDictionary[text] = text.DOColor(_color, _duration).SetEase(_curve).SetId($"{text.GetInstanceID()}TextColor");
            });
        }
    }
}
