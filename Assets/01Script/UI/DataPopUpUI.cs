using DG.Tweening;
using DKProject.Combat;
using DKProject.Core;
using DKProject.SkillSystem;
using DKProject.Weapon;
using System;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

namespace DKProject.UI
{
    public class DataPopUpUI : OutAreaToggleUI
    {
        public override string Key => nameof(DataPopUpUI);

        [SerializeField] private Pair<DataPopUpPanel, DataPopUpPanel> _dataPopUpPanelPair;
        [SerializeField] private Button _leftItemBtn, _rightItemBtn;

        private DataPopUpPanel _currentPopUpPanel;
        private InvenSlot _currentSlot;

        private void Start()
        {
            Close();
            _outButton.OnClickEvent += Close;
            _currentPopUpPanel = _dataPopUpPanelPair.first;

            _leftItemBtn.OnClickEvent += OnChangeLeftEvent;
            _rightItemBtn.OnClickEvent += OnChangeRightEvent;
        }

        private void OnChangeLeftEvent()
        {
            if (_currentSlot.PrevSlot == null) return;

            InvenSlot invenSlot = _currentSlot.PrevSlot;
            _currentPopUpPanel.RectTransform.DOAnchorPosX(2000, 0.1f);
            _currentPopUpPanel = _dataPopUpPanelPair.FindSameTypePair(_currentPopUpPanel);
            _currentPopUpPanel.RectTransform.anchoredPosition = new Vector2(-2000, 0);
            _currentPopUpPanel.RectTransform.DOAnchorPosX(0, 0.1f);
            SetItem(invenSlot);
        }

        private void OnChangeRightEvent()
        {
            if (_currentSlot.NextSlot == null) return;

            InvenSlot invenSlot = _currentSlot.NextSlot;
            _currentPopUpPanel.RectTransform.DOAnchorPosX(-2000, 0.1f);
            _currentPopUpPanel = _dataPopUpPanelPair.FindSameTypePair(_currentPopUpPanel);
            _currentPopUpPanel.RectTransform.anchoredPosition = new Vector2(2000, 0);
            _currentPopUpPanel.RectTransform.DOAnchorPosX(0, 0.1f);
            SetItem(invenSlot);
        }

        public void SetItem(InvenSlot invenSlot)
        {
            _currentSlot = invenSlot;
            ItemSO itemSO = invenSlot.ItemSO;
            Action upgrade = () =>
            {
                
                if(itemSO.itemType == ItemType.Skill)
                {
                    SkillSaveManager.Instance.LevelUpSkill(itemSO as SkillSO);
                }
                
                if(itemSO.itemType == ItemType.Weapon)
                {
                    WeaponManager.Instance.LevelUpWeapon(itemSO as WeaponSO);
                }

                UpdateLevel(itemSO);
                invenSlot.UpdateLevel();
            };

            _currentPopUpPanel.SetData(itemSO.icon, itemSO.itemName, itemSO.itemDescription, upgrade, null);
            UpdateLevel(itemSO);
        }

        private void UpdateLevel(ItemSO itemSO)
        {
            _currentPopUpPanel.SetLevel(SkillSaveManager.Instance.GetSkillLevel(itemSO as SkillSO), "");
        }

        public override void Open()
        {
            base.Open();
            ActiveElement(true);
        }

        public override void Close()
        {
            base.Close();
            ActiveElement(false);
        }
    }
}
