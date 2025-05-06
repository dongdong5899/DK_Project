using DG.Tweening;
using DKProject.Combat;
using DKProject.Core.Pool;
using DKProject.Entities;
using DKProject.Entities.Components;
using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace DKProject.SkillSystem.Skills
{
    public class ShootBumerang : LifeTime, IPoolable
    {
        private Caster2D _caster;
        private RaycastHit2D[] _hits;

        public GameObject GameObject => gameObject;

        public Enum PoolEnum => _poolingType;
        [SerializeField] private ProjectilePoolingType _poolingType;
        private Transform _owner,_target;
        private Rigidbody2D _rigidBody;
        private LayerMask _whatIsTarget;
        private BigInteger _damage;
        private List<Entity> _hitEnemy = new();
        private float _speed;
        private bool _isReturning = false;

        private void Awake()
        {
            _caster = GetComponent<Caster2D>();
            _rigidBody = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (_isReturning)
            {
                dir = (_owner.position - transform.position).normalized;
                if (Vector2.Distance(_owner.position, (Vector2)transform.position) <= 0.1f)
                {
                    _hitEnemy.Clear();
                    this.Push();
                }
            }
            else
            {
                dir = (_target.position - transform.position).normalized;
                if (Vector2.Distance(_target.position, (Vector2)transform.position) <= 0.1f)
                {
                    _isReturning = true;
                    _hitEnemy.Clear();
                }
            }

            _rigidBody.linearVelocity = dir * _speed;



            if (_caster.CheckCollision(out _hits, _whatIsTarget))
            {
                foreach (var hit in _hits)
                {
                    if (hit.transform.TryGetComponent(out Entity entity))
                    {
                        if (!_hitEnemy.Contains(entity))
                        {
                            entity.GetCompo<EntityHealth>().ApplyDamage(_damage);
                            _hitEnemy.Add(entity);
                        }
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

        public void Setting(Transform owner, Transform target, LayerMask whatIsTarget, BigInteger damage, float lifeTime)
        {
            _owner = owner;
            _target = target;
            _whatIsTarget = whatIsTarget;
            _damage = damage;
            _lifeTime = lifeTime;

            Init(lifeTime, this);


        }
    }
}
