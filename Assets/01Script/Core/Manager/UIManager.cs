using DKProject.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.Core
{
    public class UIManager : MonoSingleton<UIManager>
    {
        private Dictionary<string, UIBase> _windowPanelDictionary = new Dictionary<string, UIBase>();
        private Dictionary<string, IToggleUI> _togglePanelDictionary = new Dictionary<string, IToggleUI>();
        private List<UIBase> _windowPanelList = new List<UIBase>();

        private void Awake()
        {
            _windowPanelList = FindObjectsByType<UIBase>(FindObjectsSortMode.None).ToList();
            foreach (UIBase uiBase in _windowPanelList)
            {
                _windowPanelDictionary.Add(uiBase.Key, uiBase);
                if (uiBase is IToggleUI toggleUI)
                    _togglePanelDictionary.Add(uiBase.Key, toggleUI);
            }
        }

        public UIBase OpenUI(string key)
        {
            _togglePanelDictionary[key].Open();
            return _windowPanelDictionary[key];
        }

        public UIBase CloseUI(string key)
        {
            _togglePanelDictionary[key].Open();
            return _windowPanelDictionary[key];
        }

        public T GetUI<T>(string key) where T : UIBase
        {
            return _windowPanelDictionary[key] as T;
        }
    }
}