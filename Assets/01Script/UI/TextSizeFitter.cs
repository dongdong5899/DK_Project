using DKProject.Core;
using Doryu.CustomAttributes;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextSizeFitter : MonoBehaviour
    {
        [SerializeField] private ESizeDirection fitDirection;
        [SerializeField] private bool _usedByFixedTextLength;

        [ToggleField("_usedByFixedTextLength")]
        [SerializeField] private int _textLength;

        private TextMeshProUGUI _tmp;
        public TextMeshProUGUI TMP
        {
            get
            {
                if (_tmp == null) _tmp = GetComponent<TextMeshProUGUI>();
                return _tmp;
            }
        }
        public RectTransform RectTrm => transform as RectTransform;


        private void OnValidate()
        {
            SetFontSize();
        }

        private void OnEnable()
        {
            SetFontSize();
        }

        private void SetFontSize()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent as RectTransform);
            StartCoroutine(DelaySetWidth());
        }

        private IEnumerator DelaySetWidth()
        {
            yield return null;
            yield return null;

            if (fitDirection == ESizeDirection.Width)
            {
                float width = RectTrm.rect.width;
                if (_usedByFixedTextLength) width /= _textLength;

                width = Mathf.Clamp(width, 0, RectTrm.rect.height);
                TMP.fontSize = width;
            }

            if (fitDirection == ESizeDirection.Heigth)
            {
                float height = RectTrm.rect.height;
                if (_usedByFixedTextLength) height /= _textLength;

                height = Mathf.Clamp(height, 0, RectTrm.rect.width);
                TMP.fontSize = height;
            }
        }
    }
}
