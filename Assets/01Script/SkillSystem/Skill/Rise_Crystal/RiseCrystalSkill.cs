using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class RiseCrystalSkill : Skill
    {
        [SerializeField] private float _lifeTime;

        public override void UseSkill()
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(_owner.transform.position, SkillSO.skillRange, _whatIsTarget);

            RiseCrystal riseCrystal = PoolManager.Instance.Pop(ProjectilePoolingType.Rise_Crystal) as RiseCrystal;

            riseCrystal.transform.position = targets[0].transform.position;

            riseCrystal.Setting(_whatIsTarget, DamageCalculation((double)_player.GetAttackDamage()), _lifeTime);
        }


        public override Skill Clone()
        {
            return new RiseCrystalSkill();
        }
    }
}
