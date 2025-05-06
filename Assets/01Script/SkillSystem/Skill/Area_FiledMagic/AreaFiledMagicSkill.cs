using DKProject.EffectSystem;
using DKProject.Entities.Components;
using DKProject.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class AreaFiledMagicSkill : RangeSkill
    {
        public override void Init(Entity owner, SkillSO SO)
        {
            base.Init(owner, SO);
        }

        public override void UseSkill()
        {
            if (_colliders.Length > 0)
            {
                foreach (Collider2D target in _colliders)
                {
                    if (target.transform.TryGetComponent(out Entity entity))
                    {
                        entity.GetCompo<EntityHealth>().ApplyDamage(DamageCalculation((double)_player.GetAttackDamage()));
                    }
                }
            }
        }
    }
}
