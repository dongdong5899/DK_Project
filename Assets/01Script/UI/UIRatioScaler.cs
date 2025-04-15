using DKProject.Core;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DKProject.UI
{
    public class UIRatioScaler : MonoBehaviour
    {
        public ESizeDirectionFlag direction;
        public UnityEvent<Vector2> onChangeScale;

        public Vector2 ratio;
        private Vector2 screenSize => new Vector2(Screen.width, Screen.height);
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
            Vector2 size = RectTrm.sizeDelta;

            if ((direction & ESizeDirectionFlag.Width) != 0)
            {
                float width = screenSize.x * (ratio.x * 0.01f);
                size.x = width;
            }

            if ((direction & ESizeDirectionFlag.Heigth) != 0)
            {
                float height = screenSize.y * (ratio.y * 0.01f);
                size.y = height;
            }

            RectTrm.sizeDelta = size;
            onChangeScale?.Invoke(size);
        }
    }
}
