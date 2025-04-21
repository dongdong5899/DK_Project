using UnityEngine;

namespace DKProject.UI
{
    public abstract class ManagedUI : MonoUI
    {
        public abstract string Key { get; }
    }
    public class MonoUI : MonoBehaviour
    {
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
