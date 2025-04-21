using Doryu.CustomAttributes;
using System;
using System.Data.Common;
using UnityEngine;

namespace DKProject.UI.Events
{
    [CreateAssetMenu(fileName = "UIEventSO", menuName = "SO/UI/UIEvent")]
    public class UIEventSO : ScriptableObject
    {
        public string eventClassName;
        [SerializeField, Uncorrectable] private string _classNameIs;
        private Type _type;

        private void OnValidate()
        {
            TypeFind();
            if (_type != null)
                _classNameIs = eventClassName;
            else
                _classNameIs = "";
        }

        private void TypeFind()
        {
            if (_type != null && _type.Name == eventClassName) return;

            string className = $"{GetType().Namespace}.{eventClassName}";
            try
            {
                _type = Type.GetType(className);
            }
            catch
            {
                Debug.LogWarning($"{className} is not found.");
            }
        }

        public UIEvent CreateInstance()
        {
            if (_type != null)
            {
                UIEvent uiEvent = Activator.CreateInstance(_type) as UIEvent;
                return uiEvent;
            }
            else
            {
                return null;
            }
        }
    }
}
