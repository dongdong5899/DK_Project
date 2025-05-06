using DKProject.Core.Pool;
using DKProject.Core;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class ShootBounceBallSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;
        [SerializeField] private byte _skillCount;

        public override void UseSkill()
        {
            ShootGomuLine shootGomuLine = PoolManager.Instance.Pop(ProjectilePoolingType.Shooting_GomuLine) as ShootGomuLine;

            shootGomuLine.transform.position = _owner.transform.position;

            shootGomuLine.Setting(
                _colliders.GetRandomElement().transform.position,
                _whatIsTarget,
                DamageCalculation((double)_player.GetAttackDamage()),
                _lifeTime,
                _skillProjectileSpeed
            );
        }
    }
}
