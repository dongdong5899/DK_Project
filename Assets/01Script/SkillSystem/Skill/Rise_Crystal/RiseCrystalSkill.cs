using DKProject.Core;
using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class RiseCrystalSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;

        public override void UseSkill()
        {
            RiseCrystal riseCrystal = PoolManager.Instance.Pop(ProjectilePoolingType.Rise_Crystal) as RiseCrystal;

            riseCrystal.transform.position = _colliders.GetRandomElement().transform.position;

            riseCrystal.Setting(_whatIsTarget, DamageCalculation((double)_player.GetAttackDamage()), _lifeTime);
        }
    }
}
