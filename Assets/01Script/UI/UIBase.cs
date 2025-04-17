using UnityEngine;

namespace DKProject.UI
{
    public abstract class TogglePanelUIBase : MonoBehaviour
    {
        public abstract string Key { get; }

        private RectTransform _rectTransform;
        public RectTransform RectTransform
        {
            get
            {
                if (_rectTransform == null)
                    _rectTransform = transform as RectTransform;

                return _rectTransform;
            }
        }
    }
}
