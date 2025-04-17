using DG.Tweening;
using UnityEngine;

namespace DKProject.UI
{
    public class UserConveientDropDown : TogglePanel
    {
        [SerializeField] private RectTransform _dropDownBox;
        [SerializeField] private float _easingDuration = 0.2f;

        private Tween _toggleTween;

        public override string Key => "UserConveientDropDown";

        public override void Open()
        {
            if (_toggleTween != null && _toggleTween.active) 
                _toggleTween.Kill();

            _toggleTween = _dropDownBox.DOAnchorPosY(0, _easingDuration);
        }

        public override void Close()
        {
            if (_toggleTween != null && _toggleTween.active)
                _toggleTween.Kill();

            _toggleTween = _dropDownBox.DOAnchorPosY(_dropDownBox.rect.height, _easingDuration);
        }
    }
}
