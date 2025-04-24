namespace DKProject.UI
{
    public class StatUpgradePanel : ToggleUI
    {
        public override string Key => nameof(StatUpgradePanel);

        protected override void Awake()
        {
            base.Awake();
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
