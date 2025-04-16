using DKProject.Core;
using DKProject.Core.Pool;
using DKProject.Entities.Components;
using DKProject.Entities;
using System;
using UnityEngine;
using DKProject.Combat;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


namespace DKProject.SkillSystem.Skill
{
    public class FallStone : MonoBehaviour, IPoolable
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

        private void Awake()
        {
            _caster = GetComponent<Caster2D>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector2 dir = (_targetPosition - (Vector2)transform.position).normalized;
            _rb.linearVelocity = dir * _speed;

            //if (Vector2.Distance(_targetPosition, (Vector2)transform.position) <= 0.3f)
            //{
            //    PoolManager.Instance.Push(this);
            //}


            if (_caster.CheckCollision(out _hits, _whatIsTarget))
            {
                foreach (var hit in _hits)
                {
                    if (hit.transform.TryGetComponent(out Entity entity))
                    {
                        entity.GetCompo<EntityHealth>().ApplyDamage(_damage);
                        PoolManager.Instance.Push(this);
                    }
                }
            }
        }

        public void Setting(Vector2 target, float speed, LayerMask whatIsEnemy, BigInteger damage)
        {
            _targetPosition = target;
            _speed = speed;
            _whatIsTarget = whatIsEnemy;
            _damage = damage;
        }

        public void OnPop()
        {
        }

        public void OnPush()
        {
        }
    }
}
