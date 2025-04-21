using DG.Tweening;
using DKProject.UI;
using UnityEngine;

namespace DKProject.UI
{
    public class EnforceUI : TogglePanel, IToggleUI
    {
        public override string Key => nameof(EnforceUI);

        protected override void Awake()
        {
            base.Awake();
            base.Close();
        }

        public override void Open()
        {
            base.Open();
        }

        public override void Close()
        {
            base.Close();
        }
    }
}