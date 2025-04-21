using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.UI
{
    public class ButtonGroupPanel : ManagedUI
    {
        public override string Key => nameof(ButtonGroupPanel);

        [SerializeField] private List<PanelStruct> _buttons;
        private TogglePanel _selectedPanel = null;


        private void Awake()
        {
            foreach (PanelStruct panelData in _buttons)
            {
                panelData.trigger.OnClickEvent += () => SelectButton(panelData);
            }
        }

        public void SelectButton(PanelStruct panelData = default)
        {
            if (_selectedPanel == panelData.panel)
            {
                _selectedPanel?.Close();
                _selectedPanel = null;
                return;
            }

            _selectedPanel?.Close();
            _selectedPanel = panelData.panel;
            _selectedPanel?.Open();
        }
    }

    [Serializable]
    public struct PanelStruct
    {
        public Button trigger;
        public TogglePanel panel;
    }
}
