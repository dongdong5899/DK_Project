using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DKProject.UI
{
    public class Toggle : MonoBehaviour, IPointerClickHandler
    {
        protected bool _isEnabled; 
        public UnityEvent onEnabled; 
        public UnityEvent onDisabled;
        public UnityEvent<bool> onToggleTriggered;

        public void Trigger()
        {
            _isEnabled = !_isEnabled;
            onToggleTriggered?.Invoke(_isEnabled);

            if (_isEnabled) Enable();
            else Disable();
        }

        public void Enable()
        {
            onEnabled?.Invoke();
        }

        public void Disable()
        {
            onDisabled?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Trigger();
        }
    }
}
