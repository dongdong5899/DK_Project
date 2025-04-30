using DKProject.Entities.Components;
using DKProject.Entities;
using UnityEngine;
using DKProject.Core.Pool;

namespace DKProject.SkillSystem.Skills
{
    public class ShootBumerangSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;

        public override void UseSkill()
        {
            Collider2D farTarget = GetTargetForDistance(true);

            ShootBumerang bumerang = PoolManager.Instance.Pop(ProjectilePoolingType.ShootBumerang) as ShootBumerang;
            bumerang.transform.position = _owner.transform.position;
            bumerang.Setting(_owner.transform, farTarget.transform, _whatIsTarget, DamageCalculation((double)_player.GetAttackDamage()), _lifeTime);
        }
    }
}
