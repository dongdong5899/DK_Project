using DKProject.Entities;
using DKProject.Entities.Components;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class AreaElectricSkill : RangeSkill
    {

        private double _damage;
        [SerializeField] private float _skillDotAttackReduction;

        public override void Init(Entity owner, SkillSO SO)
        {
            base.Init(owner, SO);
            _damage = (double)_player.GetAttackDamage() * _skillDotAttackReduction / 100;
        }

        public override void UseSkill()
        {
            Collider2D target = GetTargetForDistance(true);

            if (target.transform.TryGetComponent(out Entity entity))
            {
                entity.GetCompo<EntityHealth>().ApplyDamage(DamageCalculation(_damage));
            }
        }
    }

}
