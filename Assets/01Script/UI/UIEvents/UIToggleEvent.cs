using DKProject.Core;
using UnityEngine;

namespace DKProject.UI.Events
{
    public class UIToggleEvent : UIEvent
    {
        [SerializeField] private string _panelName;
        [SerializeField] private bool _isOpen;

        public override void EventPlay()
        {
            if (_isOpen) UIManager.Instance.OpenUI(_panelName);
            else UIManager.Instance.CloseUI(_panelName);
        }
    }
}
