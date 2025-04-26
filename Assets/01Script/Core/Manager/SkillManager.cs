using DKProject.SkillSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.Core
{
    public class SkillManager : MonoSingleton<SkillManager>
    {

        private List<Skill> _enabledSkillList = new List<Skill>(6);
        [SerializeField] private bool _autoMode;



        private void Awake()
        {
            _enabledSkillList = new List<Skill> { null, null, null, null, null, null };
        }

        private void Update()
        {
            _enabledSkillList.ForEach(skill => skill?.Update());

            if (_autoMode == true)
            {
                foreach(var skill in _enabledSkillList)
                {
                    if (skill == null)
                        return;
                    if (skill.CoolTimeCheck()&&skill.RangeCheck())
                    {
                        skill?.SetUseSkill(true);
                    }
                }
            }
        }

        public void SetSlot(List<Skill> skills)
        {
            List<Skill> prevSkill = _enabledSkillList.ToList();
            _enabledSkillList.Clear();

            for (int i = 0; i < skills.Count; i++)
            {
                Skill skill = skills[i];

                if (skill == null)
                {
                    _enabledSkillList.Add(null);
                }
                else
                {
                    if (prevSkill.Count > i && prevSkill[i] != null
                        && prevSkill[i] == skill)
                    {
                        _enabledSkillList.Add(skill);
                    }
                    else
                    {
                        skill.OnEquipSkill();
                        _enabledSkillList.Add(skill);
                    }
                }
            }
        }

        public void EquipSkill(Skill skill, int idx)
        {

            if (_enabledSkillList[idx] == null)
            {
                _enabledSkillList[idx] = skill;
                _enabledSkillList[idx].OnEquipSkill();
            }
        }

        

        public void UnEquipSkill(int idx)
        {
            if (_enabledSkillList[idx] != null)
            {
                _enabledSkillList[idx].OnUnEquipSkill();
                _enabledSkillList[idx] = null;
            }
        }

        public void UseSkill(int idx)
        {
            if (_enabledSkillList[idx].SkillSO.skillType == SkillType.Passive) 
                return;
            _enabledSkillList[idx].SetUseSkill(true);
        }

        public List<Skill> GetSkillList()
        {
            return _enabledSkillList;
        }

        public bool CheckSkillEquip(SkillSO skillSO)
        {
            foreach (var skill in _enabledSkillList)
            {
                if (skill.SkillSO == skillSO)
                {
                    return true;
                }
            }
            return false;
        }

    }
}

