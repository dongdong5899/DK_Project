using DKProject.Core.Pool;
using DKProject.Core;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class FollowBearDollSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _speed;

        public override void UseSkill()
        {
            FollowTrashCan shootGomuLine = PoolManager.Instance.Pop(ProjectilePoolingType.FollowTrashCan) as FollowTrashCan;

            shootGomuLine.transform.position = _owner.transform.position;

            shootGomuLine.Setting(
                _colliders.GetRandomElement().transform,
                _whatIsTarget,
                DamageCalculation((double)_player.GetAttackDamage()),
                _lifeTime,
                _speed
            );
        }
    }
}
