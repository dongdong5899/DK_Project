using System;
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

        public T GetUIEvent<T>() where T : UIEvent
        {
            try
            {
                return Activator.CreateInstance(type) as T;
            }
            catch
            {
                Debug.LogWarning($"Class named {className} is not exsist");
                return null;
            }
        }
    }
}
