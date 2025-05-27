using DKProject.Combat;
using DKProject.Core.Pool;
using DKProject.Entities.Components;
using DKProject.Entities;
using System;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace DKProject.SkillSystem.Skills
{
    public class SpinBlade : MonoBehaviour, IPoolable
    {
        private Caster2D _caster;
        private RaycastHit2D[] _hits;

        public GameObject GameObject => gameObject;

        public Enum PoolEnum => _poolingType;
        [SerializeField] private ProjectilePoolingType _poolingType;
        private LayerMask _whatIsTarget;
        private float _spinSpeed, _angle, _radius;
        private BigInteger _damage;
        private Transform _owner;

        private void Awake()
        {
            _caster = GetComponent<Caster2D>();
        }


        public void OnPop()
        {
        }

        public void OnPush()
        {
        }

        public void Update()
        {
            _angle += _spinSpeed * Time.deltaTime;
            // 위치 및 회전 업데이트
            UpdatePositionAndRotation();
        }

        private void UpdatePositionAndRotation()
        {
            float rad = _angle * Mathf.Deg2Rad;

            Vector3 localPos = new Vector3(
                Mathf.Cos(rad) * _radius,
                Mathf.Sin(rad) * _radius,
                0f
            );
            transform.localPosition = localPos;

            transform.rotation = Quaternion.Euler(0f, 0f, _angle);

            if (_caster.CheckCollision(out _hits, _whatIsTarget))
            {
                foreach (var hit in _hits)
                {
                    if (hit.transform.TryGetComponent(out Entity entity))
                    {
                        entity.GetCompo<EntityHealth>().ApplyDamage(_damage);
                    }
                    //else if(hit.transform.TryGetComponent(out EnemyBullet bullet))
                    //{
                    //    bullet.Push();
                    //}
                }
            }
        }

        public void Setting(Transform owner, float spinSpeed, BigInteger damage, float radius, float initialAngle,LayerMask whatIsTarget)
        {
            _owner = owner;
            _spinSpeed = spinSpeed;
            _damage = damage;
            _whatIsTarget = whatIsTarget;
            _angle = initialAngle;
            _radius = radius;


            float rad = _angle * Mathf.Deg2Rad;
            transform.localPosition = new UnityEngine.Vector3(
                Mathf.Cos(rad) * _radius,
                0f,
                Mathf.Sin(rad) * _radius
            );
            transform.localRotation = Quaternion.Euler(0f, _angle, 0f);
        }
    }
}
