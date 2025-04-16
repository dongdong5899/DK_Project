using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.UI
{
    public class BottomButtonPanel : MonoBehaviour
    {
        private int _selectedIndex = -1;
        private List<Button> _buttons;

        private void Awake()
        {
            _buttons = GetComponentsInChildren<Button>().ToList();

            for (int i = 0; i < _buttons.Count; i++)
            {
                int index = i;
                _buttons[i].OnClick.AddListener(() => SelectButton(index));
            }
        }

        public void SelectButton(int index)
        {
            _selectedIndex = index;

            if (index == -1)
            {
                for (int i = 0; i < _buttons.Count; i++)
                    _buttons[i].Enable();

                return;
            }

            for (int i = 0; i < _buttons.Count; i++)
            {
                if (i == index) _buttons[i].Enable();
                else _buttons[i].Disable();
            }
        }
    }
}
