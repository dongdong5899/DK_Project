using DG.Tweening;
using DKProject.Core;
using UnityEngine;

namespace DKProject.UI
{
    public abstract class TogglePanel : ManagedUI, IToggleUI
    {
        protected CanvasGroup _canvasGruop;
        [SerializeField] protected Button _outButton;

        private RectTransform _parentRectTrm;

        protected virtual void Awake()
        {
            _canvasGruop = GetComponent<CanvasGroup>();
            _parentRectTrm = transform.parent as RectTransform;
        }

        public virtual void Open()
        {
            ActiveElement(true);
            _parentRectTrm.DOKill();
            _parentRectTrm.DOAnchorPosY(0, 0.2f).SetEase(Ease.OutExpo);
        }

        public virtual void Close()
        {
            _parentRectTrm.DOKill();
            _parentRectTrm.DOAnchorPosY(-2000, 0.2f).SetEase(Ease.OutExpo)
                .OnComplete(() => ActiveElement(false));
        }

        private void ActiveElement(bool active)
        {
            _canvasGruop.alpha = active ? 1 : 0;
            _canvasGruop.blocksRaycasts = active;
            _canvasGruop.interactable = active;
            _outButton.gameObject.SetActive(active);
        }
    }
}
