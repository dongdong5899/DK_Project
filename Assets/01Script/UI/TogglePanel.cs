using UnityEngine;

namespace DKProject.UI
{
    public abstract class TogglePanel : ManagedUI, IToggleUI
    {
        [SerializeField] private GameObject _outButton;

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
            _outButton.SetActive(true);
        }

        public virtual void Close()
        {
            _canvasGruop.alpha = 0;
            _canvasGruop.blocksRaycasts = false;
            _canvasGruop.interactable = false;
            _outButton.SetActive(false);
        }
    }
}
