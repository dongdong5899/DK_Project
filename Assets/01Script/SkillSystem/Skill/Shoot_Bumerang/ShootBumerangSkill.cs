using DKProject.Entities.Components;
using DKProject.Entities;
using UnityEngine;
using DKProject.Core.Pool;

namespace DKProject.SkillSystem.Skills
{
    public class ShootBumerangSkill : Skill
    {
        [SerializeField] private float _lifeTime;

        public override Skill Clone()
        {
            return new ShootBumerangSkill();
        }

        public override void UseSkill()
        {
            RaycastHit2D[] targets = Physics2D.CircleCastAll(_owner.transform.position, SkillSO.skillRange, Vector2.zero, 0, _whatIsTarget);

            RaycastHit2D farTarget = targets[0];
            float maxDist = farTarget.distance;

            if (targets.Length > 0)
            {
                foreach (RaycastHit2D target in targets)
                {
                    if (target.distance > maxDist)
                    {
                        farTarget = target;
                        maxDist = target.distance;
                    }
                }

                ShootBumerang bumerang = PoolManager.Instance.Pop(ProjectilePoolingType.ShootBumerang) as ShootBumerang;
                bumerang.Setting(farTarget.transform,_whatIsTarget,DamageCalculation((double)_player.GetAttackDamage()), _lifeTime);
            }
        }
    }
}
