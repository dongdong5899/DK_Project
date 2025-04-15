using DKProject.Core;
using Doryu.CustomAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DKProject.UI
{
    public class WidthHeightFitter : MonoBehaviour
    {
        public UnityEvent<Vector2> OnFitSize;
        [SerializeField] private ESizeDirection _fitDirection;

        [SerializeField] private bool _setDelay;
        [ToggleField("_setDelay")]
        [SerializeField] private int _delayFrame;

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
            if (_setDelay == false)
                SizeFitEvent();
            else
                StartCoroutine(DelayFitSize());
        }


        private IEnumerator DelayFitSize()
        {
            for (int i = 0; i < _delayFrame; i++) yield return null;
            SizeFitEvent();
        }

        private void SizeFitEvent()
        {
            Vector2 size = Vector2.zero;
            if (_fitDirection == ESizeDirection.Width)
            {
                float height = RectTrm.rect.height;
                size.y = height;
                RectTrm.sizeDelta = new Vector2(height, RectTrm.sizeDelta.y);
            }

            if (_fitDirection == ESizeDirection.Heigth)
            {
                float width = RectTrm.rect.width;
                size.x = width;
                RectTrm.sizeDelta = new Vector2(RectTrm.sizeDelta.x, width);
            }

            OnFitSize?.Invoke(size);
        }
    }
}
