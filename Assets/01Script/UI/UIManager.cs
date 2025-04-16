using DKProject.Cores;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.UI
{
    public class UIManager : MonoSingleton<UIManager>
    {
        private Dictionary<string, UIBase> _windowPanelDictionary;

        protected override void CreateInstance()
        {
            base.CreateInstance();

            List<UIBase> windowPanelList;

            //FindObjectsByType(windowPanelList);
        }
    }
}