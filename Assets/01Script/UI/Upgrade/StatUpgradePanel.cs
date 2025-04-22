namespace DKProject.UI
{
    public class StatUpgradePanel : TogglePanel
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
