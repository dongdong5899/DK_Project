using System;
using System.Data.Common;
using UnityEngine;

namespace DKProject.UI.Events
{
    [CreateAssetMenu(menuName = "SO/UI/UIEvent")]
    public class UIEventSO : ScriptableObject
    {
        [Tooltip("class name without namespace")]
        public string className;
        public Type type;

        private void OnValidate()
        {
            try
            {
                type = Type.GetType($"DKProject.UI.Events.{className}");
            }
            catch
            {
                Debug.LogWarning($"Class named {className} is not exsist");
            }
        }

        public bool GetUIEvent<T>(out T uiEvent) where T : UIEvent
        {
            try
            {
                var eventInstance = Activator.CreateInstance(type);

                if (eventInstance is T)
                {
                    uiEvent = eventInstance as T;
                    return true;
                }

                uiEvent = null;
                return false;
            }
            catch
            {
                Debug.LogWarning($"Class named {className} is not exsist");
                uiEvent = null;
                return false;
            }
        }
    }
}
