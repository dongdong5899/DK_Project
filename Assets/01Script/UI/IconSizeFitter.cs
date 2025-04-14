using DKProject.Core;
using UnityEngine;

namespace DKProject.UI
{
    public class IconSizeFitter : MonoBehaviour
    {
        [SerializeField] private ESizeDirection _fitDirection;

        private RectTransform RectTrm => transform as RectTransform;

        private void OnValidate()
        {
            FitSize();
        }

        private void OnEnable()
        {
            FitSize();
        }


        public void FitSize()
        {
            if(_fitDirection == ESizeDirection.Width)
            {
                RectTrm.sizeDelta = new Vector2(RectTrm.sizeDelta.y, RectTrm.sizeDelta.y);
            }

            if(_fitDirection == ESizeDirection.Heigth)
            {
                RectTrm.sizeDelta = new Vector2(RectTrm.sizeDelta.x, RectTrm.sizeDelta.x);
            }
        }
    }
}
