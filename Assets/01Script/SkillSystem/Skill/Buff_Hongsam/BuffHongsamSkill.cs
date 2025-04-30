using DKProject.EffectSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class BuffHongsamSkill : Skill
    {
        [SerializeField] private List<EffectSO> buffEffects;
        public override void OnEquipSkill()
        {
            base.OnEquipSkill();
            AddEffect(buffEffects);
        }

        public override void OnUnEquipSkill()
        {
            base.OnUnEquipSkill();
            RemoveEffect(buffEffects);
        }

        public override void UseSkill()
        {
        }

        
    }
}
