using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DKProject.UI
{
    public class Button : MonoUI, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField] private List<UIEventData> _downEventList;
        [SerializeField] private List<UIEventData> _upEventList;

        public Action OnClickEvent;
        public Action<bool> OnPressEvent;

        private void Awake()
        {
            foreach (var eventData in _downEventList)
                eventData.Init(this);
            foreach (var eventData in _upEventList)
                eventData.Init(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            foreach (UIEventData uiEventData in _downEventList)
            {
                uiEventData.UIEvent.EventPlay();
            }
            OnPressEvent?.Invoke(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            foreach (UIEventData uiEventData in _upEventList)
            {
                uiEventData.UIEvent.EventPlay();
            }
            OnPressEvent?.Invoke(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickEvent?.Invoke();
        }
    }
}
