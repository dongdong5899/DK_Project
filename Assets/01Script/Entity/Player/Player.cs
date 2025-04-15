using DKProject.Cores;
using DKProject.Entities.Components;
using DKProject.Entities.Enemies;
using DKProject.FSM;
using DKProject.StatSystem;
using System;
using System.Numerics;
using UnityEngine;

namespace DKProject.Entities.Players
{
    public class Player : Entity
    {
        private EntityState _entityState;
        private PlayerRenderer _entityRenderer;
        private EntityStat _entityStat;
        private StatElement _attackSpeedStat;
        private float _lastAttackTime;
        [SerializeField] private string _attakcDamage = "10";
        private BigInteger _attakcDamageBigInteger;

        public bool IsCanAttack()
            => _lastAttackTime + 1f / _attackSpeedStat.Value < Time.time;
        public void CheckAttackTime()
            => _lastAttackTime = Time.time;
        public void Attack(Enemy enemy)
        {
            enemy.GetCompo<EntityHealth>().ApplyDamage(_attakcDamageBigInteger++);
        }

        protected override void Awake()
        {
            _attakcDamageBigInteger = BigInteger.Parse(_attakcDamage);
            base.Awake();
        }

        protected override void AfterInitComponents()
        {
            base.AfterInitComponents();
            _entityState = GetCompo<EntityState>();
            _entityRenderer = GetCompo<PlayerRenderer>();
            _entityStat = GetCompo<EntityStat>();
            _attackSpeedStat = _entityStat.StatDictionary[StatName.AttackSpeed];
        }

        protected override void DisposeComponents()
        {
            base.DisposeComponents();
        }
    }
}