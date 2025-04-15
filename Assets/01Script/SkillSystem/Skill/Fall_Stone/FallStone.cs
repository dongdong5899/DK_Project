using DKProject.Cores.Pool;
using System;
using UnityEngine;


namespace DKProject.SkillSystem.Skill
{
    public class FallStone : MonoBehaviour, IPoolable
    {
        public GameObject GameObject => gameObject;
        public Enum PoolEnum => _poolingType;
        [SerializeField] private ProjectilePoolingType _poolingType;

        private Vector2 _targetPosition;
        private float _speed;
        private void Update()
        {
            Vector2 dir = (_targetPosition - (Vector2)transform.position).normalized;
            transform.position += (Vector3)dir * _speed * Time.deltaTime;

            if (Vector2.Distance(_targetPosition, (Vector2)transform.position) <= 0.3f)
            {
                PoolManager.Instance.Push(this);
            }
        }

        public void Setting(Vector2 target, float speed)
        {
            _targetPosition = target;
            _speed = speed;
        }

        public void OnPop()
        {
        }

        public void OnPush()
        {
        }
    }
}
