using DKProject.Core;
using DKProject.Core.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class ThrowAnythingSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;
        [SerializeField] private List<Sprite> _spriteList;
        public override void UseSkill()
        {
            ThrowAnything throwAnything = PoolManager.Instance.Pop(ProjectilePoolingType.Throw_Anything) as ThrowAnything;

            throwAnything.transform.position = _owner.transform.position;

            throwAnything.Setting(
                _colliders.GetRandomElement().transform.position,
                _whatIsTarget,
                DamageCalculation((double)_player.GetAttackDamage()),
                _lifeTime,
                _skillProjectileSpeed,
                _spriteList
            );
        }
    }
}
