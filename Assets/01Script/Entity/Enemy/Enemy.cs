using DKProject.Entities.Components;
using DKProject.StatSystem;
using UnityEngine;

namespace DKProject.Entities.Enemies
{
    public class Enemy : Entity
    {
        private EntityStat _entityStat;
        private StatElement _attackSpeedStat;
        private float _lastAttackTime;

        public bool IsCanAttack()
            => _lastAttackTime + 1f / _attackSpeedStat.Value < Time.time;
        public void CheckAttackTime()
            => _lastAttackTime = Time.time;
        public void Attack()
        {
            //Debug.Log("Enemy's Attack");
        }

        protected override void AfterInitComponents()
        {
            base.AfterInitComponents();
            _entityStat = GetCompo<EntityStat>();
            _attackSpeedStat = _entityStat.StatDictionary[StatName.AttackSpeed];
        }
    }
}
