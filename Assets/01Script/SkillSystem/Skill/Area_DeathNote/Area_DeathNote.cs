using DKProject.Core;
using DKProject.Entities;
using DKProject.Entities.Components;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class Area_DeathNote : RangeSkill
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
            Entity target = _colliders.GetRandomElement().GetComponent<Entity>();
            if (target)
            {
                target.GetCompo<EntityHealth>().ApplyDamage(DamageCalculation(_damage));
            }
        }
    }
}
