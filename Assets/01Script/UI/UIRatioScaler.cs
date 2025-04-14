using DKProject.Core;
using UnityEngine;
using UnityEngine.Events;

namespace DKProject.UI
{
    public class UIRatioScaler : MonoBehaviour
    {
        public ESizeDirectionFlag direction;
        public UnityEvent<Vector2> onChangeScale;

        public Vector2 ratio;
        private Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        private RectTransform RectTrm => transform as RectTransform;


        private void OnValidate()
        {
            SetSize();
        }

        private void OnEnable()
        {
            SetSize();
        }

        private void SetSize()
        {
            if ((direction & ESizeDirectionFlag.Width) != 0)
            {
                float width = screenSize.x / (ratio.x / 100f);
                RectTrm.sizeDelta = new Vector2(width, RectTrm.sizeDelta.y);
            }

            if ((direction & ESizeDirectionFlag.Heigth) != 0)
            {
                float height = screenSize.y * (ratio.y / 100f);
                RectTrm.sizeDelta = new Vector2(RectTrm.sizeDelta.x, height);
            }

            onChangeScale?.Invoke(RectTrm.sizeDelta);
        }
    }
}
