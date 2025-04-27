using DKProject.Entities.Components;
using DKProject.Entities;
using UnityEngine;
using System.Collections.Generic;

namespace DKProject.SkillSystem.Skills
{
    public class BuffIceCream : Skill
    {
        private double _damage;
        [SerializeField] private List<EffectSO> _effectList;
        [SerializeField] private float _skillDotAttackReduction;

        public override void Init(Entity owner, SkillSO SO)
        {
            base.Init(owner, SO);
            _damage = (double)_player.GetAttackDamage() * _skillDotAttackReduction / 100;
        }

        public override Skill Clone()
        {
            return new BuffIceCream();
        }

        public override void UseSkill()
        {
            RaycastHit2D[] targets = Physics2D.CircleCastAll(_owner.transform.position, SkillSO.skillRange, Vector2.zero, 0, _whatIsTarget);

            if (targets.Length > 0)
            {
                foreach (RaycastHit2D target in targets)
                {
                    if (target.transform.TryGetComponent(out Entity entity))
                    {
                        entity.GetCompo<EntityHealth>().ApplyDamage(this.DamageCalculation(_damage));
                        AddEffect(entity, _effectList);
                    }
                }
            }
        }
    }
}
