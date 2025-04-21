using DKProject.Core;
using UnityEngine;

namespace DKProject.UI
{
    public class ShopUI : TogglePanel
    {
        public override string Key => "Shop";
        private CanvasGroup _canvasGruop;
        [SerializeField] private Button _outButton;


        protected override void Awake()
        {
            base.Awake();
            _canvasGruop = GetComponent<CanvasGroup>();
            _outButton.OnClick += () => UIManager.Instance.GetUI<ButtonGroupPanel>("BottomButtonGroup").SelectButton(-1);
            Close();
        }

        public override void Close()
        {
            base.Close();
            _outButton.gameObject.SetActive(false);
        }

        public override void Open()
        {
            base.Open();
            _outButton.gameObject.SetActive(true);
        }
    }
}
