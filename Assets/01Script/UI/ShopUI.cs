using DKProject.Core;

namespace DKProject.UI
{
    public class ShopUI : TogglePanel
    {
        public override string Key => nameof(ShopUI);

        protected override void Awake()
        {
            base.Awake();
            _outButton.OnClickEvent += () => UIManager.Instance.GetUI<ButtonGroupPanel>(nameof(ButtonGroupPanel)).SelectButton();
            Close();
        }
    }
}
