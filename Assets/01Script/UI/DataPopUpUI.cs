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
            Debug.Log("Asdasd");
            _currentSlot = invenSlot;
            ItemSO itemSO = invenSlot.ItemSO;
            _currentPopUpPanel.SetEquipData(SkillManager.Instance.CheckSkillEquip(itemSO as SkillSO, out int index));
            Action upgrade = () =>
            {

                ItemManager.Instance.LevelUpItem(itemSO as SkillSO);
                
                UpdateLevel(itemSO);
                invenSlot.UpdateLevel();
            };
            Action equip = () =>
            {
                if (SkillManager.Instance.CheckSkillEquip(itemSO as SkillSO, out int index))
                {
                    SkillManager.Instance.UnEquipSkill(index);
                    _currentPopUpPanel.SetEquipData(false);
                }
                else
                {
                    SkillSlotSettingController slotSettingController
                        = UIManager.Instance.OpenUI(nameof(SkillSlotSettingController)) as SkillSlotSettingController;
                    slotSettingController.SetSkill(SkillManager.Instance.GetSkillClass(itemSO as SkillSO));
                    _currentPopUpPanel.SetEquipData(true);
                }
            };

            _currentPopUpPanel.SetData(itemSO.icon, itemSO.itemName, itemSO.itemDescription, upgrade, null, equip);
            UpdateLevel(itemSO);
        }

        private void UpdateLevel(ItemSO itemSO)
        {
            int level = 0,price = 0;
            if (itemSO.itemType == ItemType.Skill)
            {
                level = SkillSaveManager.Instance.GetItemLevel(itemSO as SkillSO);
                price = (int)SkillSaveManager.Instance.GetItemUpgradePrice(itemSO as SkillSO);
            }
            if (itemSO.itemType == ItemType.Weapon)
            {
                level = WeaponSaveManager.Instance.GetItemLevel(itemSO as WeaponSO);
                //price = WeaponManager.Instance.GetWeaponUpgradePrice(itemSO as SkillSO);
            }
            _currentPopUpPanel.SetLevel(level, price.ToString(), "");
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
