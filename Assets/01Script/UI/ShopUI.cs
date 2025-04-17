using UnityEngine;

namespace DKProject.UI
{
    public class ShopUI : TogglePanel
    {
        public override string Key => "Shop";

        protected override void Awake()
        {
            base.Awake();
            Close();
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
