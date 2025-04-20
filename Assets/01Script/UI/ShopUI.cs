using DKProject.Core;
using UnityEngine;

namespace DKProject.UI
{
    public class ShopUI : TogglePanel
    {
        public override string Key => "Shop";
        private CanvasGroup _canvasGruop;
        [SerializeField] private Button _outButton;


        private void Awake()
        {
            _canvasGruop = GetComponent<CanvasGroup>();
            _outButton.OnClick += () => UIManager.Instance.GetUI<ButtonGroupPanel>("BottomButtonGroup").SelectButton(-1);
            Close();
        }

        public override void Close()
        {
            _canvasGruop.alpha = 0;
            _canvasGruop.blocksRaycasts = false;
            _canvasGruop.interactable = false;
            _outButton.gameObject.SetActive(false);
        }

        public override void Open()
        {
            _canvasGruop.alpha = 1;
            _canvasGruop.blocksRaycasts = true;
            _canvasGruop.interactable = true;
            _outButton.gameObject.SetActive(true);
        }
    }
}
