using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DKProject.UI
{
    public class Button : EventPlayer, IPointerDownHandler, IPointerUpHandler
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
    }
}
