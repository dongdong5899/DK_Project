using DG.Tweening;
using DKProject.Combat;
using DKProject.Core.Pool;
using System.Numerics;
using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using DKProject.Entities.Components;
using DKProject.Entities;

namespace DKProject
{
    public class FollowBearDoll : LifeTime, IPoolable
    {
        private Caster2D _caster;
        private RaycastHit2D[] _hits;

        public GameObject GameObject => gameObject;

        public Enum PoolEnum => _poolingType;
        [SerializeField] private ProjectilePoolingType _poolingType;
        private Transform _target;
        private LayerMask _whatIsTarget;
        private float _speed;
        private BigInteger _damage;
        private Rigidbody2D _rb;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _caster = GetComponent<Caster2D>();
        }


        private void Update()
        {
            Vector2 dir = ((Vector2)_target.position - (Vector2)transform.position).normalized;
            _rb.linearVelocity = dir * _speed;

            if (Vector2.Distance((Vector2)_target.position, (Vector2)transform.position) <= 0.2f)
            {
                DOVirtual.DelayedCall(0.5f, () =>
                {
                    if (_caster.CheckCollision(out _hits, _whatIsTarget))
                    {
                        foreach(RaycastHit2D hit in _hits)
                        {
                            if (_hits[0].transform.TryGetComponent(out Entity entity))
                            {
                                entity.GetCompo<EntityHealth>().ApplyDamage(_damage);
                                //ÀÌÆåÆ® »ý¼º
                            }
                        }
                    }
                    PoolManager.Instance.Push(this);
                });
            }
        }

        public void OnPop()
        {
        }

        public void OnPush()
        {
        }

        public void Setting(Transform target, LayerMask whatIsTarget, BigInteger damage, float lifeTime, float speed)
        {
            _target = target;
            _whatIsTarget = whatIsTarget;
            _damage = damage;
            _speed = speed;

            Init(lifeTime, this);
        }
    }
}
