using DKProject.Core;
using DKProject.SkillSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.UI
{
    public class SkillSlotSettingController : OutAreaToggleUI
    {
        public override string Key => nameof(SkillSlotSettingController);

        private List<SkillSlotSettingUI> _skillSlotSettingUIList;
        private Skill[] _skills;
        private Skill _skill;
        public event Action<int> OnSkillEquipEvent;

        protected override void Awake()
        {
            base.Awake();

            _skills = SkillManager.Instance.GetSkillArr();
            _skillSlotSettingUIList = new List<SkillSlotSettingUI>();
            GetComponentsInChildren(_skillSlotSettingUIList);
            for (int i = 0; i < _skillSlotSettingUIList.Count; i++)
            {
                int index = i;
                _skillSlotSettingUIList[i].Init(i);
                _skillSlotSettingUIList[i].OnClickEvent += () => OnSlotClickEvent(index);
            }
            UpdateSkillSlot();

            _outButton.OnClickEvent += Close;
        }

        public void SetSkill(Skill skill)
        {
            _skill = skill;
        }

        public void OnSlotClickEvent(int index)
        {
            SkillManager.Instance.EquipSkill(_skill, index);
            _skillSlotSettingUIList[index].SetSkill(_skill);
            OnSkillEquipEvent?.Invoke(index);
            Close();
        }

        public void UpdateSkillSlot()
        {
            for (int i = 0; i < _skillSlotSettingUIList.Count; i++)
            {
                _skillSlotSettingUIList[i].SetSkill(_skills[i]);
            }
        }

        public override void Open()
        {
            base.Open();
            ActiveElement(true);
            UpdateSkillSlot();
        }

        public override void Close()
        {
            base.Close();
            ActiveElement(false);
        }
    }
}
