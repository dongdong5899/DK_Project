using DKProject.Combat;
using DKProject.Core.Pool;
using DKProject.EffectSystem;
using DKProject.Entities.Components;
using DKProject.Entities;
using System.Collections.Generic;
using System.Numerics;
using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using DKProject.Core;

namespace DKProject.SkillSystem.Skills
{
    public class ThrowAnything : LifeTime,IPoolable
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
        private SpriteRenderer _renderer;
        private List<Sprite> _spriteList;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _caster = GetComponent<Caster2D>();
            _renderer = GetComponent<SpriteRenderer>();
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
            _renderer.sprite = _spriteList.GetRandomElement(); 
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
