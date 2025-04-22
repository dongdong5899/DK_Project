namespace DKProject.UI
{
    public class WeaponUpgradePanel : TogglePanel
    {
        public override string Key => nameof(WeaponUpgradePanel);

        protected override void Awake()
        {
            base.Awake();
            Close();
        }

        public override void Open()
        {
            ActiveElement(true);
        }

        public override void Close()
        {
            ActiveElement(false);
        }
    }
}
