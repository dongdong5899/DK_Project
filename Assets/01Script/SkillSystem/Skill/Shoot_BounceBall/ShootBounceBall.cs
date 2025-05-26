using DKProject.Combat;
using DKProject.Core.Pool;
using DKProject.EffectSystem;
using DKProject.Entities.Components;
using DKProject.Entities;
using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using NUnit.Framework;
using System.Collections.Generic;
using Vector3 = UnityEngine.Vector3;

namespace DKProject.SkillSystem.Skills
{
    public class ShootBounceBall : MonoBehaviour, IPoolable
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
        private Entity _owner;
        private Vector2 _dir;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _caster = GetComponent<Caster2D>();
        }



        private void Update()
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

            // X축 반사
            if (screenPos.x < 0 || screenPos.x > Screen.width)
            {
                _rb.linearVelocity = new Vector2(-_rb.linearVelocity.x, _rb.linearVelocity.y);
            }

            // Y축 반사
            if (screenPos.y < 0 || screenPos.y > Screen.height)
            {
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, -_rb.linearVelocity.y);
            }

            // 충돌 체크
            if (_caster.CheckCollision(out _hits, _whatIsTarget))
            {
                foreach (RaycastHit2D hit in _hits)
                {
                    if (hit.transform.TryGetComponent(out Entity entity))
                    {
                        entity.GetCompo<EntityHealth>().ApplyDamage(_damage);
                    }
                }
            }

            Vector3 clampPos = transform.position;
            Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, clampPos.z - Camera.main.transform.position.z));
            Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, clampPos.z - Camera.main.transform.position.z));

            clampPos.x = Mathf.Clamp(clampPos.x, min.x, max.x);
            clampPos.y = Mathf.Clamp(clampPos.y, min.y, max.y); // Y축도 필요하면
            transform.position = clampPos;
        }

        public void OnPop()
        {
        }

        public void OnPush()
        {
        }

        public void Setting(Entity owner, Vector2 targetPos, LayerMask whatIsTarget, BigInteger damage, float projectileSpeed)
        {
            _owner = owner;
            _targetPosition = targetPos;
            _whatIsTarget = whatIsTarget;
            _damage = damage;
            _speed = projectileSpeed;
            _dir = (_targetPosition - (Vector2)transform.position).normalized;
            _rb.linearVelocity = _dir * _speed;
        }
    }
}
