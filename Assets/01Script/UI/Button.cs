using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DKProject.UI
{
    public class Button : MonoUI, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField] protected List<UIEventData> _downEventList;
        [SerializeField] protected List<UIEventData> _upEventList;

        public Action OnClickEvent;
        public Action<bool> OnPressEvent;

        protected virtual void Awake()
        {
            foreach (var eventData in _downEventList)
                eventData.Init(this);
            foreach (var eventData in _upEventList)
                eventData.Init(this);
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            foreach (UIEventData uiEventData in _downEventList)
            {
                uiEventData.UIEvent.EventPlay();
            }
            OnPressEvent?.Invoke(true);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            foreach (UIEventData uiEventData in _upEventList)
            {
                uiEventData.UIEvent.EventPlay();
            }
            OnPressEvent?.Invoke(false);
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            OnClickEvent?.Invoke();
        }
    }
}
