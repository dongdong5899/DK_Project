using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DKProject.UI
{
    public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public UnityEvent OnStartClick;
        public UnityEvent OnClick;

        private CanvasGroup _canvasGroup;
        [SerializeField] private float _enableAlpha, _disableAlpha;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnStartClick?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }


        public void Enable()
        {
            _canvasGroup.alpha = _enableAlpha;
        }

        public void Disable()
        {
            _canvasGroup.alpha = _disableAlpha;
        }
    }
}
