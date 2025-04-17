using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DKProject.UI
{
    public class Button : EventPlayer, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnStartClick;
        public event Action OnClick;
        private UIEventController eventController;

        private void Awake()
        {
            eventController = GetComponentInChildren<UIEventController>();
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
