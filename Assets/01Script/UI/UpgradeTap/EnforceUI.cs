using DG.Tweening;
using DKProject.Core;
using DKProject.UI;
using UnityEngine;

namespace DKProject.UI
{
    public class EnforceUI : TogglePanel
    {
        public override string Key => nameof(EnforceUI);

        protected override void Awake()
        {
            base.Awake();
            _outButton.OnClickEvent += () => UIManager.Instance.GetUI<ButtonGroupPanel>(nameof(ButtonGroupPanel)).SelectButton();
            Close();
        }
    }
}