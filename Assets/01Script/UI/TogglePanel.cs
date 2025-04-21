using DKProject.Core;
using UnityEngine;

namespace DKProject.UI
{
    public abstract class TogglePanel : ManagedUI, IToggleUI
    {
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
        }

        public virtual void Close()
        {
            _canvasGruop.alpha = 0;
            _canvasGruop.blocksRaycasts = false;
            _canvasGruop.interactable = false;
            _outButton.gameObject.SetActive(false);
        }
    }
}
