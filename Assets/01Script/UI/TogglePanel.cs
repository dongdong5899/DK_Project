using DKProject.Core;
using System;
using UnityEngine;

namespace DKProject.UI
{
    public abstract class TogglePanel : ManagedUI, IToggleUI
    {
        public Action onCompleteOpen;
        public Action onCompleteClose;

        protected CanvasGroup _canvasGruop;
        [SerializeField] protected Button _outButton;


        protected virtual void Awake()
        {
            _canvasGruop = GetComponent<CanvasGroup>();
        }

        public virtual void Open()
        {
            _canvasGruop.alpha = 1;
            _canvasGruop.blocksRaycasts = true;
            _canvasGruop.interactable = true;
            _outButton.gameObject.SetActive(true);
            onCompleteOpen?.Invoke();
        }

        public virtual void Close()
        {
            _canvasGruop.alpha = 0;
            _canvasGruop.blocksRaycasts = false;
            _canvasGruop.interactable = false;
            _outButton.gameObject.SetActive(false);
            onCompleteClose?.Invoke();
        }
    }
}
