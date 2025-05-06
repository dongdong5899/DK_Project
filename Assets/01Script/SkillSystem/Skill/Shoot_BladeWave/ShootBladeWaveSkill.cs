using DKProject.Core.Pool;
using DKProject.Core;
using UnityEngine;
using DKProject.EffectSystem;
using System.Collections.Generic;

namespace DKProject.SkillSystem.Skills
{
    public class ShootBladeWaveSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;
        [SerializeField] private byte _skillCount;

        [SerializeField] private List<EffectSO> _effects;
        public override void UseSkill()
        {
            ShootBladeWave bladeWave = PoolManager.Instance.Pop(ProjectilePoolingType.Shoot_PineTree) as ShootBladeWave;

            bladeWave.transform.position = _owner.transform.position;

            bladeWave.Setting(
                _colliders.GetRandomElement().transform.position,
                _whatIsTarget,
                DamageCalculation((double)_player.GetAttackDamage()),
                _lifeTime,
                _skillProjectileSpeed,
                _effects
            );
        }
    }
}
