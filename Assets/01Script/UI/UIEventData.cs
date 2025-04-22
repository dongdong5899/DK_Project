using DKProject.UI.Events;
using DKProject.UI;
using UnityEngine;
using System;

namespace DKProject
{
    [Serializable]
    public class UIEventData : ISerializationCallbackReceiver
    {
        public UIEventSO eventSO;
        [SerializeReference] public UIEvent UIEvent;

        public void Init(MonoUI monoUI)
        {
            UIEvent?.EventInit(monoUI);
        }

        public void OnAfterDeserialize()
        {
        }

        public void OnBeforeSerialize()
        {
            if (eventSO == null)
                UIEvent = null;
            else if (UIEvent == null || UIEvent.GetType().Name != eventSO.eventClassName)
            {
                //Debug.Log($"{eventSO.eventClassName}"); 
                Debug.Log($"{eventSO.eventClassName} | {UIEvent == null}");
                UIEvent = eventSO.CreateInstance();
            }
        }
    }
}
