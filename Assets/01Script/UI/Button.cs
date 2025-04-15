using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DKProject.UI
{
    public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        public UnityEvent OnClick;
        public UnityEvent OnStartClick;
        public UnityEvent OnEndClick;


        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnStartClick?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnEndClick?.Invoke();
        }
    }
}
