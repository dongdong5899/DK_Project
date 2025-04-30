using DKProject.Entities.Components;
using DKProject.Entities;
using UnityEngine;
using System.Collections.Generic;
using DKProject.EffectSystem;

namespace DKProject.SkillSystem.Skills
{
    public class BuffIceCreamSkill : RangeSkill
    {
        private double _damage;
        [SerializeField] private List<EffectSO> _effectList;
        [SerializeField] private float _skillDotAttackReduction;

        public override void Init(Entity owner, SkillSO SO)
        {
            base.Init(owner, SO);
            _damage = (double)_player.GetAttackDamage() * _skillDotAttackReduction / 100;
        }

        public override void UseSkill()
        {
            foreach (Collider2D target in _colliders)
            {
                if (target.transform.TryGetComponent(out Entity entity))
                {
                    entity.GetCompo<EntityHealth>().ApplyDamage(DamageCalculation(_damage));
                }
            }
        }
    }
}
