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
            FollowBearDoll followBearDoll = PoolManager.Instance.Pop(ProjectilePoolingType.Follow_BearDoll) as FollowBearDoll;

            followBearDoll.transform.position = _owner.transform.position;

            followBearDoll.Setting(
                _colliders.GetRandomElement().transform,
                _whatIsTarget,
                DamageCalculation((double)_player.GetAttackDamage()),
                _lifeTime,
                _speed
            );
        }
    }
}
