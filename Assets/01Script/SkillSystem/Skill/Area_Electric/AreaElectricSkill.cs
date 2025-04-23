using DKProject.Entities;
using DKProject.Entities.Components;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class AreaElectricSkill : Skill
    {
        public override void UseSkill()
        {
            RaycastHit2D[] targets = Physics2D.CircleCastAll(_owner.transform.position, SkillSO.skillRange,Vector2.zero,0,_whatIsTarget);

            RaycastHit2D closeTarget = targets[0];
            float minDist = closeTarget.distance;

            if (targets.Length>0)
            {
                foreach (RaycastHit2D target in targets)
                {
                    if (target.distance < minDist)
                    {
                        closeTarget = target;
                        minDist = target.distance;
                    }
                }

                if(closeTarget.transform.TryGetComponent(out Entity entity))
                    entity.GetCompo<EntityHealth>().ApplyDamage(this.DamageCalculation());
            }

        }

        public override Skill Clone()
        {
            return new FallStoneSkill();
        }
    }

}
