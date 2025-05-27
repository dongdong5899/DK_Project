using DKProject.Core;
using DKProject.SkillSystem;
using System;
using UnityEngine;
using UnityEngine.UI;
using Button = DKProject.UI.Button;

namespace DKProject
{
    [Serializable]
    public struct GachaPanelInfo
    {
        public Button button;
        public ItemType itemType;
    }

    public class GachaPanelBtnController : MonoBehaviour
    {
        [SerializeField] private GachaPanelInfo[] _gachaPanelInfo;
        [SerializeField] private Color _enableBtnColor, _disableBtnColor;

        private ItemType _currentItemType;
        private Image _image;

        private void Start()
        {
            bool isFirst = true;
            foreach (var panelInfo in _gachaPanelInfo)
            {
                Image image = panelInfo.button.GetComponent<Image>();
                panelInfo.button.OnClickEvent += () => ClickButton(panelInfo.itemType, image);
                if (isFirst)
                {
                    ClickButton(panelInfo.itemType, image);
                    isFirst = false;
                }
            }
        }

        private void ClickButton(ItemType itemType, Image image)
        {
            if (_currentItemType == itemType) return;
            _currentItemType = itemType;
            GachaManager.Instance.SetCurrentGachaItem(_currentItemType);

            if (_image != null) _image.color = _disableBtnColor;
            _image = image;
            if (_image != null) _image.color = _enableBtnColor;
        }
    }
}
