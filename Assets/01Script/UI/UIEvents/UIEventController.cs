using DG.Tweening;
using DKProject.UI.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.UI
{
    public class UIEventController : MonoBehaviour
    {
        public List<UIEventSO> UIEventSO;

        [SerializeReference] private List<ToggleEvent> ToggleEvents;
        [SerializeReference] private List<PlayEvent> PlayEvents;

        private void OnValidate()
        {
            UIEventSO?.ForEach(eventSO =>
            {
                bool hasToggleEvent = ToggleEvents.Any(uiEvent => uiEvent.GetType() == eventSO.type);
                if (!hasToggleEvent) eventSO.GetUIEvent<ToggleEvent>();

                bool hasPlayEvent = PlayEvents.Any(uiEvent => uiEvent.GetType() == eventSO.type);
                if (!hasPlayEvent) eventSO.GetUIEvent<PlayEvent>();
            });
        }


        public void PlayEvent()
        {
            PlayEvents.ForEach(UIEvent => UIEvent.Play());
        }

        public void EnableEvent()
        {
            ToggleEvents.ForEach(UIEvent => UIEvent.Enable());
        }

        public void DisableEvent()
        {
            ToggleEvents.ForEach(UIEvent => UIEvent.Disable());
        }
    }
}