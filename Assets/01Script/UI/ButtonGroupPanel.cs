using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.UI
{
    public class ButtonGroupPanel : MonoBehaviour
    {
        [SerializeField] private List<PanelStruct> _buttons;
        private int _selectedIndex = -1;

        private void Awake()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                int index = i;
                _buttons[i].trigger.OnClick += () => SelectButton(index);
            }
        }

        public void SelectButton(int index)
        {
            if (_selectedIndex == index) return;
            _selectedIndex = index;

            if (index == -1)
            {
                for (int i = 0; i < _buttons.Count; i++)
                    _buttons[i].panel?.Close();

                return;
            }

            for (int i = 0; i < _buttons.Count; i++)
            {
                if (i == index) _buttons[i].panel?.Open();
                else _buttons[i].panel?.Close();
            }
        }
    }

    [Serializable]
    public struct PanelStruct
    {
        public Button trigger;
        public TogglePanel panel;
    }
}
