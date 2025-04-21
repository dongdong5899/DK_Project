using DKProject.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.Core
{
    public class UIManager : MonoSingleton<UIManager>
    {
        private Dictionary<string, ManagedUI> _windowPanelDictionary = new Dictionary<string, ManagedUI>();
        private Dictionary<string, IToggleUI> _togglePanelDictionary = new Dictionary<string, IToggleUI>();
        private List<ManagedUI> _windowPanelList = new List<ManagedUI>();

        private void Awake()
        {
            _windowPanelList = FindObjectsByType<ManagedUI>(FindObjectsSortMode.None).ToList();
            foreach (ManagedUI uiBase in _windowPanelList)
            {
                _windowPanelDictionary.Add(uiBase.Key, uiBase);
                if (uiBase is IToggleUI toggleUI)
                {
                    _togglePanelDictionary.Add(uiBase.Key, toggleUI);
                    Debug.Log(uiBase.Key);
                }
            }
        }

        public ManagedUI OpenUI(string key)
        {
            _togglePanelDictionary[key].Open();
            return _windowPanelDictionary[key];
        }

        public ManagedUI CloseUI(string key)
        {
            _togglePanelDictionary[key].Open();
            return _windowPanelDictionary[key];
        }

        public T GetUI<T>(string key) where T : ManagedUI
        {
            return _windowPanelDictionary[key] as T;
        }
    }
}