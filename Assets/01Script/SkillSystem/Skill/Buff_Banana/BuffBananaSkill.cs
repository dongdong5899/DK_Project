using DKProject.EffectSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class BuffBananaSkill : Skill
    {
        [SerializeField] private List<EffectSO> buffEffects;
        public override void OnEquipSkill()
        {
            base.OnEquipSkill();
            //AddEffect(_owner, buffEffects);
        }

        public override void OnUnEquipSkill()
        {
            base.OnUnEquipSkill();
            //RemoveEffect(_owner, buffEffects);
        }

        public override Skill Clone()
        {
            return new BuffHongsamSkill();
        }

        public override void UseSkill()
        {
        }

    }
}
