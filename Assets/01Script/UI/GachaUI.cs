using DKProject.Core;
using UnityEngine;

namespace DKProject.UI
{
    public class GachaUI : BottomUI
    {
        public override string Key => nameof(GachaUI);

        protected override void Awake()
        {
            base.Awake();
            _outButton.OnClickEvent += () => UIManager.Instance.GetUI<ButtonGroupPanel>(nameof(ButtonGroupPanel)).SelectButton();
            ActiveElement(false);
        }
    }
}
