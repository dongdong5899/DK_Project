using UnityEngine;

namespace DKProject.UI
{
    public abstract class OutAreaToggleUI : TogglePanel
    {
        [SerializeField] protected Button _outButton;

        public override void ActiveElement(bool active)
        {
            base.ActiveElement(active);
            _outButton?.gameObject.SetActive(active);
        }
    }
}
