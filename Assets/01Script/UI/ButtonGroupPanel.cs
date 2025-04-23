using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.UI
{
    public class ButtonGroupPanel : ManagedUI
    {
        public override string Key => nameof(ButtonGroupPanel);

        [SerializeField] private List<TogglePanelInfo> _buttons;
        private TogglePanel _selectedPanel = null;


        private void Awake()
        {
            foreach (TogglePanelInfo panelData in _buttons)
            {
                panelData.button.OnClickEvent += () => SelectButton(panelData.panel);
            }
        }

        public void SelectButton(TogglePanel panel = null)
        {
            if (_selectedPanel == panel || panel == null)
            {
                _selectedPanel?.Close();
                _selectedPanel = null;
                return;
            }

            if (_selectedPanel != null)
            {
                _selectedPanel.ActiveElement(false);
                _selectedPanel = panel;
                _selectedPanel.ActiveElement(true);
            }
            else
            {
                _selectedPanel = panel;
                _selectedPanel.Open();
            }
        }
    }

    [Serializable]
    public struct TogglePanelInfo
    {
        public Button button;
        public TogglePanel panel;
    }
}
