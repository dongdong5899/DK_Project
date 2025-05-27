using DG.Tweening;
using DKProject.Core;
using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class ShootGomuLineSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;
        [SerializeField] private byte _skillCount;

        public override void UseSkill()
        {
            ShootGomuLine shootGomuLine = PoolManager.Instance.Pop(ProjectilePoolingType.Shoot_GomuLine) as ShootGomuLine;

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
