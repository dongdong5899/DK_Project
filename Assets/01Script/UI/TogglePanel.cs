using UnityEngine;

namespace DKProject.UI
{
    public abstract class TogglePanel : UIBase, IToggleUI
    {
        public abstract void Close();

        public abstract void Open();
    }
}
