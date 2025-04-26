using DKProject.Entities.Players;
using DKProject.SkillSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.Core
{
    public class SkillManager : MonoSingleton<SkillManager>
    {
        private Dictionary<SkillSO, Skill> _skillClassDictionary = new();
        private Skill[] _equipedSkills = new Skill[6];
        [SerializeField] private bool _autoMode;
        [SerializeField] private SkillListSO _skillSOList;

        private void Start()
        {
            Player player = PlayerManager.Instance.Player;
            foreach (SkillSO skillSO in _skillSOList.GetList())
            {
                _skillClassDictionary.Add(skillSO, skillSO.GetSkill(player));
            }
        }

        private void Update()
        {
            for (int i = 0; i < _equipedSkills.Length; i++)
            {
                Skill skill = _equipedSkills[i];
                skill?.Update();
                if (skill != null && _autoMode)
                {
                    if (skill.CoolTimeCheck() && skill.RangeCheck())
                    {
                        skill.SetUseSkill(true);
                    }
                }
            }
        }

        public void SetSlot(Skill[] skills)
        {
            for (int i = 0; i < skills.Length; i++)
            {
                if (_equipedSkills[i] != skills[i])
                {
                    _equipedSkills[i]?.OnUnEquipSkill(); // 이전꺼 빼고
                    skills[i]?.OnEquipSkill(); //새로운거 넣고
                }
            }
            _equipedSkills = skills;
        }

        public Skill EquipSkill(Skill skill, int idx)
        {
            Skill prevSkill = _equipedSkills[idx];

            _equipedSkills[idx]?.OnUnEquipSkill();
            _equipedSkills[idx] = skill;
            _equipedSkills[idx]?.OnEquipSkill();

            return prevSkill;
        }

        public Skill UnEquipSkill(int idx)
        {
            Skill prevSkill = _equipedSkills[idx];

            _equipedSkills[idx]?.OnUnEquipSkill();
            _equipedSkills[idx] = null;

            return prevSkill;
        }

        public void UseSkill(int idx)
        {
            if (_equipedSkills[idx].SkillSO.skillType == SkillType.Passive)
                return;
            _equipedSkills[idx].SetUseSkill(true);
        }

        public Skill[] GetSkillArr()
        {
            return _equipedSkills;
        }

        public Skill GetSkillClass(SkillSO skillSO)
        {
            return _skillClassDictionary[skillSO];
        }

        public int GetSkillUpgradePrice(SkillSO skillSO)
        {
            switch (skillSO.skillRank)
            {
                case Rank.Common:
                    return 1;
                case Rank.Rare:
                    return 1;
                case Rank.Unique:
                    return 2;
                case Rank.Epic:
                    return 3;
                case Rank.Legendary:
                    return 5;
                default:
                    return -1;
            }
        }

        public bool CheckSkillEquip(SkillSO skillSO, out int index)
        {
            for (int i = 0; i < _equipedSkills.Length; i++)
            {
                if (_equipedSkills[i] != null &&  _equipedSkills[i].SkillSO == skillSO)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
    }
}

