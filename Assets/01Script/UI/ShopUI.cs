using UnityEngine;

namespace DKProject.UI
{
    public class ShopUI : TogglePanel
    {
        public override string Key => "Shop";
        private CanvasGroup _canvasGruop;
        [SerializeField] private GameObject _outButton;


        private void Awake()
        {
            _canvasGruop = GetComponent<CanvasGroup>();
            Close();
        }

        public override void Close()
        {
            _canvasGruop.alpha = 0;
            _canvasGruop.blocksRaycasts = false;
            _canvasGruop.interactable = false;
            _outButton.SetActive(false);
        }

        public override void Open()
        {
            _canvasGruop.alpha = 1;
            _canvasGruop.blocksRaycasts = true;
            _canvasGruop.interactable = true;
            _outButton.SetActive(true);
        }
    }
}
