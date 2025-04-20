using DKProject.Combat;
using DKProject.Cores.Pool;
using DKProject.Entities.Components;
using DKProject.Entities;
using System;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

namespace DKProject.SkillSystem.Skill
{
    public class ThrowBomb : LifeTime, IPoolable
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
            if (Vector2.Distance(_targetPosition, (Vector2)transform.position) <= 0.2f)
            {
                if (_caster.CheckCollision(out _hits, _whatIsTarget))
                {
                    foreach (var hit in _hits)
                    {
                        if (hit.transform.TryGetComponent(out Entity entity))
                        {
                            Debug.Log(hit);
                            entity.GetCompo<EntityHealth>().ApplyDamage(_damage);
                            //PoolManager.Instance.Pop(EffectPoolingType.Throw_BombEffect);
                        }
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

        public void Setting(Vector2 firePos, Vector2 targetPos, LayerMask whatIsTarget, BigInteger damage,float fireAngle,float lifeTime)
        {
            _targetPosition = targetPos;
            _whatIsTarget = whatIsTarget;
            _damage = damage;

            Init(lifeTime, this);


            float angle = fireAngle * Mathf.Deg2Rad;


            float distance = Vector2.Distance(firePos, targetPos);
            float yOffset = firePos.y - targetPos.y;

            float initVelocity = (1 / Mathf.Cos(angle))
                * Mathf.Sqrt((0.5f * _gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

            float yVelocity = initVelocity * Mathf.Sin(angle);
            float xVelocity = initVelocity * Mathf.Cos(angle);
            Vector2 velocity = new Vector2(xVelocity, yVelocity);

            Vector2 direction = (targetPos - firePos).normalized;
            float angleBetween = Vector2.SignedAngle(Vector2.right, direction);
            Vector2 finalVelocity = Quaternion.Euler(0, 0, angleBetween) * velocity;

            _rb.AddForce(finalVelocity * _rb.mass, ForceMode2D.Impulse);
            _rb.AddTorque(5f, ForceMode2D.Impulse);
        }
    }
}

