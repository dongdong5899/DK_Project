using UnityEngine;

namespace DKProject.UI
{
    public abstract class TogglePanel : ManagedUI, IToggleUI
    {
        private CanvasGroup _canvasGruop;


        protected virtual void Awake()
        {
            _canvasGruop = GetComponent<CanvasGroup>();
        }

        public virtual void Open()
        {
            _canvasGruop.alpha = 1;
            _canvasGruop.blocksRaycasts = true;
            _canvasGruop.interactable = true;
        }

        public virtual void Close()
        {
            _canvasGruop.alpha = 0;
            _canvasGruop.blocksRaycasts = false;
            _canvasGruop.interactable = false;
        }
    }
}
