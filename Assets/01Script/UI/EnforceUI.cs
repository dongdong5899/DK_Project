using DKProject.Core;

namespace DKProject.UI
{
    public class EnforceUI : BottomUI
    {
        public override string Key => nameof(EnforceUI);

        protected override void Awake()
        {
            base.Awake();
            _outButton.OnClickEvent += () => UIManager.Instance.GetUI<ButtonGroupPanel>(nameof(ButtonGroupPanel)).SelectButton();
            ActiveElement(false);
        }
    }
}