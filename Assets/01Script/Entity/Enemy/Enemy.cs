using DKProject.Core;
using DKProject.Core.Pool;
using DKProject.Entities.Components;
using DKProject.Resources;
using DKProject.StatSystem;
using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace DKProject.Entities.Enemies
{
    public class Enemy : Entity, IPoolable
    {
        private EntityStat _entityStat;
        private StatElement _attackSpeedStat;
        private float _lastAttackTime;

        [SerializeField] private List<Pair<ResourceType, Pair<int, string>>> _dropResourcesData;
        [SerializeField] private ulong _dropExp;

        public Action<Enemy> OnDieEvent;

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
            OnDieEvent?.Invoke(this);

            ItemDrop();

            this.Push();
        }

        private void ItemDrop()
        {
            float itemDropPower = 5f;
            foreach (var dropResourcePair in _dropResourcesData)
            {
                for (int i = 0; i < dropResourcePair.second.first; i++)
                {
                    DroppedResource droppedResource 
                        = gameObject.Pop(ObjectPoolingType.Resource, transform.position, Quaternion.identity) as DroppedResource;
                    droppedResource.Init(dropResourcePair.first, BigInteger.Parse(dropResourcePair.second.second), Random.insideUnitCircle * Random.Range(0f, itemDropPower));
                }
            }
            PlayerManager.Instance.AddExp(_dropExp);
        }

        protected override void AfterInitComponents()
        {
            base.AfterInitComponents();
            _entityStat = GetCompo<EntityStat>();
            _attackSpeedStat = _entityStat.StatDictionary[StatName.AttackSpeed];
        }
    }
}
