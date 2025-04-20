using DKProject.Entities;
using DKProject.Entities.Components;
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
            RaycastHit2D[] targets = Physics2D.CircleCastAll(_owner.transform.position, SkillSO.currentAreaRadius,Vector2.zero,0,_whatIsTarget);

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

                Entity entity = closeTarget.transform.GetComponent<Entity>();

                entity.GetCompo<EntityHealth>().ApplyDamage(this.DamageCalculation());
            }

        }

        public override Skill Clone()
        {
            return new FallStoneSkill();
        }
    }

}
