using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class BuffHongsamSkill : Skill
    {

        public override void OnEquipSkill()
        {
            base.OnEquipSkill();
            AddEffect(_owner);
        }

        public override void OnUnEquipSkill()
        {
            base.OnUnEquipSkill();
            RemoveEffect(_owner);
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
