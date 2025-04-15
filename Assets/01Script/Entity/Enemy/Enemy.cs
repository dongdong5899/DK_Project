using DKProject.Cores.Pool;
using DKProject.Entities.Components;
using DKProject.StatSystem;
using System;
using System.Numerics;
using UnityEngine;

namespace DKProject.Entities.Enemies
{
    public class Enemy : Entity, IPoolable
    {
        private EntityStat _entityStat;
        private StatElement _attackSpeedStat;
        private float _lastAttackTime;
        [SerializeField] private string _attakcDamage = "10";
        private BigInteger _attakcDamageBigInteger;

        #region Pooling
        public GameObject GameObject => gameObject;
        public Enum PoolEnum => _poolingType;
        [SerializeField] private EnemyPoolingType _poolingType;

        public void OnPop()
        {
            AfterInitComponents();
        }

        public void OnPush()
        {
            DisposeComponents();
        }
        #endregion

        protected override void Awake()
        {
            _attakcDamageBigInteger = BigInteger.Parse(_attakcDamage);
            FindComponents();
            InitComponents();
        }

        protected override void OnDestroy()
        {
            
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
            this.Push();
        }

        protected override void AfterInitComponents()
        {
            base.AfterInitComponents();
            _entityStat = GetCompo<EntityStat>();
            _attackSpeedStat = _entityStat.StatDictionary[StatName.AttackSpeed];
        }
    }
}
