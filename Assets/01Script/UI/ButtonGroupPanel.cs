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
<<<<<<< Updated upstream
                _buttons[i].trigger.OnClick.AddListener(() =>
                {
                    SelectButton(index);
                    _buttons[index].panel.Open();
                });
=======
                _buttons[i].trigger.OnClick += () => SelectButton(index);
>>>>>>> Stashed changes
            }
        }

        public void SelectButton(int index)
        {
<<<<<<< Updated upstream
=======
            if (_selectedIndex == index) return;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        public Toggle eventToggle;
=======
>>>>>>> Stashed changes
        public TogglePanel panel;
    }
}
