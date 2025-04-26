using DKProject.Core;
using DKProject.SkillSystem;
using DKProject.UI;
using UnityEngine;

namespace DKProject
{
    public class InvenSkill : InvenSlot
    {
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void HandleClickEvent()
        {
            DataPopUpUI dataPopUpUI = UIManager.Instance.OpenUI(nameof(DataPopUpUI)) as DataPopUpUI;
            dataPopUpUI.SetItem(this);
        }

        public override void UpdateLevel()
        {
            _level.text = $"{SkillSaveManager.Instance.GetSkillLevel(SkillSO)}";
        }
    }
}
