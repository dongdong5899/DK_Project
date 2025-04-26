using DG.Tweening;
using DKProject.Core;
using DKProject.SkillSystem;
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
            SkillSO skillSO = invenSlot.SkillSO;
            Action upgrade = () =>
            {
                SkillSaveManager.Instance.LevelUpSkill(skillSO);
                UpdateLevel(skillSO);
                invenSlot.UpdateLevel();
            };

            _currentPopUpPanel.SetData(skillSO.icon, skillSO.skillName, skillSO.skillDescription, upgrade, null);
            UpdateLevel(skillSO);
        }

        private void UpdateLevel(SkillSO skillSO)
        {
            _currentPopUpPanel.SetLevel(SkillSaveManager.Instance.GetSkillLevel(skillSO), "");
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
