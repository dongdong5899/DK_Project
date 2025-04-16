using DKProject.Core;
using DKProject.Core;
using DKProject.Core.Pool;
using DKProject.Entities.Players;
using System;
using UnityEngine;

namespace DKProject.Resources
{
    public class DroppedResource : MonoBehaviour, IPoolable
    {
        [SerializeField] private ObjectPoolingType _poolType;
        [SerializeField] private float _getRange;
        [SerializeField] private SpriteRenderer _visual;

        public GameObject GameObject => gameObject;
        public Enum PoolEnum => _poolType;

        private ResourceType _resourceType;
        private Vector2 _force;
        private System.Numerics.BigInteger _value;
        private Player _player;

        private void Awake()
        {
            _player = PlayerManager.Instance.Player;
        }

        private void Update()
        {
            transform.position += (Vector3)_force * Time.deltaTime;
            _force *= 0.9f;

            if (Vector3.Distance(_player.transform.position, transform.position) < _getRange)
            {
                ResourceManager.AddResource(_resourceType, _value);
                this.Push();
            }
        }

        public void Init(ResourceType resourceType, System.Numerics.BigInteger value, Vector2 force)
        {
            _resourceType = resourceType;
            _force = force;
            _value = value;

            switch (resourceType)
            {
                case ResourceType.EXP:
                    _visual.color = Color.red;
                    break;
                case ResourceType.Gold:
                    _visual.color = Color.yellow;
                    break;
                case ResourceType.Diamond:
                    _visual.color = Color.blue;
                    break;
                default:
                    _visual.color = Color.white;
                    break;
            }
        }

        public void OnPop()
        {

        }

        public void OnPush()
        {

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _getRange);
        }
    }
}
