using DKProject.Entities.Components;
using DKProject.Entities;
using UnityEngine;
using DKProject.EffectSystem;
using System.Collections.Generic;

namespace DKProject.SkillSystem.Skills
{
    public class AreaCrySkill : RangeSkill
    {
        private double _damage;
        [SerializeField] private float _skillDotAttackReduction;

        [SerializeField] private List<EffectSO> _effectList;

        public override void Init(Entity owner, SkillSO SO)
        {
            base.Init(owner, SO);
            _damage = (double)_player.GetAttackDamage() * _skillDotAttackReduction / 100;
        }

        public override void UseSkill()
        {
            if (_colliders.Length > 0)
            {
                foreach (Collider2D target in _colliders)
                {
                    if (target.transform.TryGetComponent(out Entity entity))
                    {
                        entity.GetCompo<EntityHealth>().ApplyDamage(DamageCalculation(_damage));
                        foreach(EffectSO effect in _effectList)
                        {
                            entity.GetCompo<EntityEffect>().ApplyEffect(effect.effectType);
                        }
                    }
                }
            }
        }
    }
}
