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
            Collider2D closeTarget = _colliders[0];
            float minDist = Vector2.Distance(closeTarget.transform.position, _player.transform.position);

            foreach (Collider2D target in _colliders)
            {
                float distance = Vector2.Distance(target.transform.position, _player.transform.position);
                if (distance < minDist)
                {
                    closeTarget = target;
                    minDist = distance;
                }
            }

            if (closeTarget.transform.TryGetComponent(out Entity entity))
            {
                entity.GetCompo<EntityHealth>().ApplyDamage(this.DamageCalculation(_damage));
            }
        }
    }

}
