using DG.Tweening;
using Doryu.CustomAttributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI.Events
{
    public class UIColorChangeEvent : UIEvent
    {
        [SerializeField] private List<Image> _targetImage;
        [SerializeField] private List<TMP_Text> _targetText;
        [SerializeField] private Color _color;
        [SerializeField] private float _duration;
        [SerializeField] private AnimationCurve _curve;

        public override void EventInit(MonoUI monoUI)
        {
            base.EventInit(monoUI);
        }

        public override void EventPlay()
        {
            _targetImage.ForEach(image =>
            {
                DOTween.Kill($"{image.GetInstanceID()}Color");
                image.DOColor(_color, _duration).SetEase(_curve).SetId($"{image.GetInstanceID()}Color");
            });
            _targetText.ForEach(text =>
            {
                DOTween.Kill($"{text.GetInstanceID()}TextColor");
                text.DOColor(_color, _duration).SetEase(_curve).SetId($"{text.GetInstanceID()}TextColor");
            });
        }
    }
}
