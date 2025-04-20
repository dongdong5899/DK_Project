using DKProject.UI.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.UI
{
    public class UIEventController : MonoBehaviour
    {
        public List<UIEventSO> UIEventSO;

        [SerializeReference] private List<ToggleEvent> ToggleEvents = new();
        [SerializeReference] private List<PlayEvent> PlayEvents = new();

        private void OnValidate()
        {
            UIEventSO?.ForEach(eventSO =>
            {
                if (eventSO == null) return;

                bool hasToggleEvent = ToggleEvents.Any(uiEvent => uiEvent.GetType() == eventSO.type);
                if (!hasToggleEvent)
                {
                    if (eventSO.GetUIEvent<ToggleEvent>(out ToggleEvent toggleEvent))
                        ToggleEvents.Add(toggleEvent);
                }

                bool hasPlayEvent = PlayEvents.Any(uiEvent => uiEvent.GetType() == eventSO.type);
                if (!hasPlayEvent) 
                {
                    if (eventSO.GetUIEvent<PlayEvent>(out PlayEvent playEvent))
                        PlayEvents.Add(playEvent);
                }
            });

            for(int i = 0; i < ToggleEvents.Count; i++)
            {
                UIEventSO uiEventSO = UIEventSO.Find(so => so.type == ToggleEvents[i].GetType());

                if(uiEventSO == null)
                    ToggleEvents.RemoveAt(i--);
            }

            for (int i = 0; i < PlayEvents.Count; i++)
            {
                UIEventSO uiEventSO = UIEventSO.Find(so => so.type == PlayEvents[i].GetType());

                if (uiEventSO == null)
                    PlayEvents.RemoveAt(i--);
            }
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