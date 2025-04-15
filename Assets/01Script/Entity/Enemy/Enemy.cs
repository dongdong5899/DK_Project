using DKProject.Entities.Components;
using DKProject.StatSystem;
using System.Numerics;
using UnityEngine;

namespace DKProject.Entities.Enemies
{
    public class Enemy : Entity
    {
        private EntityStat _entityStat;
        private StatElement _attackSpeedStat;
        private float _lastAttackTime;
        [SerializeField] private string _attakcDamage = "10";
        private BigInteger _attakcDamageBigInteger;

        protected override void Awake()
        {
            _attakcDamageBigInteger = BigInteger.Parse(_attakcDamage);
            base.Awake();
        }

        public bool IsCanAttack()
            => _lastAttackTime + 1f / _attackSpeedStat.Value < Time.time;
        public void CheckAttackTime()
            => _lastAttackTime = Time.time;
        public void Attack()
        {

        }

        public override void OnDie()
        {
            base.OnDie();
            Destroy(gameObject);
        }

        protected override void AfterInitComponents()
        {
            base.AfterInitComponents();
            _entityStat = GetCompo<EntityStat>();
            _attackSpeedStat = _entityStat.StatDictionary[StatName.AttackSpeed];
        }
    }
}
