using DKProject.Combat;
using DKProject.Core.Pool;
using DKProject.Entities.Components;
using DKProject.Entities;
using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace DKProject
{
    public class ShootPineTree : LifeTime, IPoolable
    {
        private Caster2D _caster;
        private RaycastHit2D[] _hits;

        public GameObject GameObject => gameObject;

        public Enum PoolEnum => _poolingType;
        [SerializeField] private ProjectilePoolingType _poolingType;
        private Vector2 _targetPosition;
        private LayerMask _whatIsTarget;
        private float _speed;
        private BigInteger _damage;
        private Rigidbody2D _rb;
        private float _gravity;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _gravity = _rb.gravityScale;
            _caster = GetComponent<Caster2D>();
        }


        private void Update()
        {
            Vector2 dir = (_targetPosition - (Vector2)transform.position).normalized;
            _rb.linearVelocity = dir * _speed;

            if (Vector2.Distance(_targetPosition, (Vector2)transform.position) <= 0.2f)
            {
                if (_caster.CheckCollision(out _hits, _whatIsTarget))
                {
                    if (_hits[0].transform.TryGetComponent(out Entity entity))
                    {
                        entity.GetCompo<EntityHealth>().ApplyDamage(_damage);
                    }
                }
                PoolManager.Instance.Push(this);
            }

        }

        public void OnPop()
        {
        }

        public void OnPush()
        {
        }

        public void Setting(Vector2 targetPos, LayerMask whatIsTarget, BigInteger damage, float lifeTime, float projectileSpeed)
        {
            _targetPosition = targetPos;
            _whatIsTarget = whatIsTarget;
            _damage = damage;
            _speed = projectileSpeed;


            Init(lifeTime, this);
        }
    }
}
