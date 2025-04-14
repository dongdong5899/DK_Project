using DKProject.Cores;
using DKProject.Entities.Components;
using DKProject.FSM;
using DKProject.StatSystem;
using System;
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

        public bool IsCanAttack()
            => _lastAttackTime + 1f / _attackSpeedStat.Value < Time.time;
        public void CheckAttackTime()
            => _lastAttackTime = Time.time;
        public void Attack()
        {
            Debug.Log("Attack");
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