using DG.Tweening;
using DKProject.Combat;
using DKProject.Core.Pool;
using DKProject.Entities;
using DKProject.Entities.Components;
using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
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
        private LayerMask _whatIsTarget;
        private BigInteger _damage;
        [SerializeField] private List<Entity> _hitEntities = new();

        private void Awake()
        {
            _caster = GetComponent<Caster2D>();
        }


        private void Update()
        {
            if (_caster.CheckCollision(out _hits, _whatIsTarget))
            {
                foreach (var hit in _hits)
                {
                    if (hit.transform.TryGetComponent(out Entity entity))
                    {
                        if (!_hitEntities.Contains(entity))
                        {
                            entity.GetCompo<EntityHealth>().ApplyDamage(_damage);
                            _hitEntities.Add(entity);
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
            MoveTarget();
        }
        public override void Init(float lifeTime, IPoolable poolItem)
        {
            base.Init(lifeTime, poolItem);
            _hitEntities.Clear();
        }

        public void MoveTarget()
        {
            float moveTime = _lifeTime * 0.5f;
            transform.DOMove(_target.position, moveTime).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                _hitEntities.Clear();
                transform.DOMove(_owner.position, moveTime);
            });
        }

    }
}
