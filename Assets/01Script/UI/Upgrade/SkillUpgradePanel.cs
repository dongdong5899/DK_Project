using DKProject.SkillSystem;
using DKProject.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject
{
    public class SkillUpgradePanel : ToggleUI
    {
        public override string Key => nameof(SkillUpgradePanel);

        [SerializeField] private SkillListSO _skillList;
        private InvenSlot[] _invenSkills;

        protected override void Awake()
        {
            base.Awake();
            Close();

            _invenSkills = GetComponentsInChildren<InvenSlot>();
            List<SkillSO> skillList = _skillList.GetList().OfType<SkillSO>().ToList();
            int skillCount = skillList.Count;
            for (int i = 0; i < skillCount; i++)
            {
                InvenSlot prev = i - 1 < 0 ? null : _invenSkills[i - 1];
                InvenSlot next = i + 1 >= skillCount ? null : _invenSkills[i + 1];
                _invenSkills[i].Init(prev, next, skillList[i]);
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
