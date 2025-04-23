using DKProject.Core;
using DKProject.SkillSystem;
using DKProject.UI;
using UnityEngine;

namespace DKProject
{
    public class InvenSkill : InvenSlot
    {
        private SkillSO _skillSO;

        protected override void Awake()
        {
            base.Awake();
        }

        public void SetSkillSO(SkillSO skillSO)
        {
            _skillSO = skillSO;
            _icon.sprite = _skillSO.icon;
        }

        protected override void HandleClickEvent()
        {
            Debug.Log("Skill");
            DataPopUpUI dataPopUpUI = UIManager.Instance.OpenUI(nameof(DataPopUpUI)) as DataPopUpUI;
            dataPopUpUI.SetItem(_skillSO);
        }
    }
}
