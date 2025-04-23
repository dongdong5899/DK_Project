using DKProject.Combat;
using DKProject.Core.Pool;
using DKProject.Entities.Components;
using DKProject.Entities;
using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace DKProject.SkillSystem.Skills
{
    public class RiseCrystal : LifeTime, IPoolable
    {
        private Caster2D _caster;
        private RaycastHit2D[] _hits;
        public GameObject GameObject => gameObject;
        public Enum PoolEnum => _poolingType;
        [SerializeField] private ProjectilePoolingType _poolingType;

        private LayerMask _whatIsTarget;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _caster = GetComponent<Caster2D>();
            _rb = GetComponent<Rigidbody2D>();
        }


        public void Setting(LayerMask whatIsEnemy, BigInteger damage, float lifeTime)
        {
            
            Init(lifeTime, this);

            if (_caster.CheckCollision(out _hits, whatIsEnemy))
            {
                foreach (var hit in _hits)
                {
                    if (hit.transform.TryGetComponent(out Entity entity))
                    {
                        entity.GetCompo<EntityHealth>().ApplyDamage(damage);
                    }
                }
            }
        }
        public void OnPop()
        {
        }

        public void OnPush()
        {
        }
    }
}
