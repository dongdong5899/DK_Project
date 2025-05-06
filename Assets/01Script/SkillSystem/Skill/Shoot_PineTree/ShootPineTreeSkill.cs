using DG.Tweening;
using DKProject.Core;
using DKProject.Core.Pool;
using DKProject.EffectSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class ShootPineTreeSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;
        [SerializeField] private byte _skillCount;

        [SerializeField] private List<EffectSO> _effects;
        public override void UseSkill()
        {
            ShootPineTree pineTree = PoolManager.Instance.Pop(ProjectilePoolingType.Shoot_PineTree) as ShootPineTree;

            pineTree.transform.position = _owner.transform.position;

            pineTree.Setting(
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
