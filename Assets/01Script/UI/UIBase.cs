namespace DKProject.UI
{
    public abstract class UIBase
    {
        public abstract string Key { get; }
        public abstract void Open();
        public abstract void Close();
    }
}
