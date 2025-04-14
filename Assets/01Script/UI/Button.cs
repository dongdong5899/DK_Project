using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DKProject.UI
{
    public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public UnityEvent OnClick;
        public UnityEvent<bool> OnHover;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnHover?.Invoke(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnHover?.Invoke(false);
        }
    }
}
