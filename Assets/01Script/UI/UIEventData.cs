using DKProject.UI.Events;
using DKProject.UI;
using UnityEngine;
using System;

namespace DKProject
{
    [Serializable]
    public class UIEventData : ISerializationCallbackReceiver
    {
        public UIEventSO uiEventSO;
        [SerializeReference] public UIEvent uiEvent;

        public void Init(MonoUI monoUI)
        {
            uiEvent?.EventInit(monoUI);
        }

        public void OnAfterDeserialize()
        {
            if (uiEventSO == null)
                uiEvent = null;
            else if (uiEvent == null || uiEvent.GetType().Name != uiEventSO.eventClassName)
                uiEvent = uiEventSO.CreateInstance();
        }

        public void OnBeforeSerialize()
        {
        }
    }
}
