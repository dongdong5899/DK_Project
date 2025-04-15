using DKProject.Entities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.SkillSystem.Skill
{
    public class PlayerSkillSystem : MonoBehaviour, IEntityComponent, IAfterInitable
    {
        //private Player _player;

        private List<Skill> _enabledSkillList = new List<Skill>(3);
        [SerializeField] private bool _autoMode;
        public void Initialize(Entity entity)
        {
            //_player = entity as Player;
        }

        public void AfterInit()
        {
            _enabledSkillList = new List<Skill> { null, null, null };
            //_player.PlayerInput.SkillUse += HandleUseSkill;
        }

        public void Dispose()
        {

        }

        private void HandleUseSkill(byte skillNum)
        {
            _enabledSkillList[skillNum].SetUseSkill(true);
        }

        private void Update()
        {
            _enabledSkillList.ForEach(skill => skill?.Update());
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
                skill.OnEquipSkill();
            }
        }



        public void UnEquipSkill(Skill skill, int idx)
        {
            if (_enabledSkillList[idx] != null)
            {
                _enabledSkillList[idx].OnUnEquipSkill();
                skill.OnUnEquipSkill();
                _enabledSkillList[idx] = null;
            }
        }
    }
}

