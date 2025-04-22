using DG.Tweening;
using UnityEngine;

namespace DKProject.UI
{
    public abstract class BottomUI : TogglePanel
    {
        private RectTransform _parentRectTrm;

        protected override void Awake()
        {
            base.Awake();
            _parentRectTrm = transform.parent as RectTransform;
        }

        public override void Open()
        {
            ActiveElement(true);
            _parentRectTrm.DOKill();
            _parentRectTrm.DOAnchorPosY(0, 0.2f).SetEase(Ease.OutExpo);
        }

        public override void Close()
        {
            _parentRectTrm.DOKill();
            _parentRectTrm.DOAnchorPosY(-2000, 0.2f).SetEase(Ease.OutExpo)
                .OnComplete(() => ActiveElement(false));
        }
    }
}
