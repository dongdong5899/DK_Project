using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.UI
{
    public class BottomButtonPanel : MonoBehaviour
    {
        [SerializeField] private List<PanelStruct> _buttons;
        private int _selectedIndex = -1;

        private void Awake()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                int index = i;
                _buttons[i].trigger.OnClick.AddListener(() =>
                {
                    SelectButton(index);
                    _buttons[index].panel.Open();
                });
            }
        }

        public void SelectButton(int index)
        {
            _selectedIndex = index;

            if (index == -1)
            {
                for (int i = 0; i < _buttons.Count; i++)
                {
                    _buttons[i].trigger.Enable();
                    _buttons[i].panel?.Close();
                }

                return;
            }

            for (int i = 0; i < _buttons.Count; i++)
            {
                if (i == index)
                {
                    _buttons[i].trigger.Enable();
                    _buttons[i].panel?.Open();
                }
                else
                {
                    _buttons[i].trigger.Disable();
                    _buttons[i].panel?.Close();
                }
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
