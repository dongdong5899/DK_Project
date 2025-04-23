using DKProject.SkillSystem;
using DKProject.SkillSystem.Skills;
using DKProject.UI;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject
{
    public class SkillUpgradePanel : TogglePanel
    {
        public override string Key => nameof(SkillUpgradePanel);

        [SerializeField] private SkillListSO _skillList;
        private InvenSkill[] _invenSkills;

        protected override void Awake()
        {
            base.Awake();
            Close();

            _invenSkills = GetComponentsInChildren<InvenSkill>();
            List<SkillSO> skillList = _skillList.GetList();
            for (int i = 0; i < skillList.Count; i++)
            {
                _invenSkills[i].SetSkillSO(skillList[i]);
            }
        }

        public override void Open()
        {
            ActiveElement(true);
        }

        public override void Close()
        {
            ActiveElement(false);
        }
    }
}
