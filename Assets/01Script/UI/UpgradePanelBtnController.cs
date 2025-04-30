using DKProject.Core;
using DKProject.UI;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject
{
    public class UpgradePanelBtnController : MonoBehaviour
    {
        [SerializeField] private TogglePanelInfo[] _togglePanelInfo;
        [SerializeField] private Color _enableBtnColor, _disableBtnColor;

        private ToggleUI _selectedPanel;
        private Image _image;

        private void Start()
        {
            bool isFirst = true;
            foreach (var panelInfo in _togglePanelInfo)
            {
                Image image = panelInfo.button.GetComponent<Image>();
                panelInfo.button.OnClickEvent += () => ClickButton(panelInfo.panel, image);
                if (isFirst)
                {
                    ClickButton(panelInfo.panel, image);
                    isFirst = false;
                }
            }
        }

        public void ClickButton(ToggleUI togglePanel, Image image)
        {
            if (_selectedPanel == togglePanel) return;

            _selectedPanel?.Close();
            _selectedPanel = togglePanel;
            _selectedPanel?.Open();

            if (_image != null) _image.color = _disableBtnColor;
            _image = image;
            if (_image != null) _image.color = _enableBtnColor;
        }
    }
}
