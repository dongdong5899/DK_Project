using DG.Tweening;
using DKProject.Core;
using UnityEngine;

namespace DKProject.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class TogglePanel : ManagedUI, IToggleUI
    {
        protected CanvasGroup _canvasGruop;
        [SerializeField] protected Button _outButton;

        protected virtual void Awake()
        {
            _canvasGruop = GetComponent<CanvasGroup>();
        }

        public virtual void Open() { }

        public virtual void Close() { }

        public virtual void ActiveElement(bool active)
        {
            _canvasGruop.alpha = active ? 1 : 0;
            _canvasGruop.blocksRaycasts = active;
            _canvasGruop.interactable = active;
            _outButton?.gameObject.SetActive(active);
        }
    }
}
