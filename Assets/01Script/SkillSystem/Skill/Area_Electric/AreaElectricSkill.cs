using DKProject.Entities;
using UnityEngine;

namespace DKProject.SkillSystem.Skill
{
    public class AreaElectricSkill : Skill
    {
        public override void Init(Entity owner, SkillSO SO)
        {
            base.Init(owner, SO);

        }

        public override void UseSkill()
        {
            
        }

        public override Skill Clone()
        {
            Skill skill = new FallStoneSkill();
            return skill;
        }
    }

}
