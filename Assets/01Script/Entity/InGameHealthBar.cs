using DKProject.Entities.Components;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace DKProject.Entities
{
    public class InGameHealthBar : MonoBehaviour
    {
        [SerializeField] private EntityHealth _targetHealth;
        [SerializeField] private Transform _healthBar, _changerBar;
        [SerializeField] private float _changerDelay = 0.5f;
        private float _lastChangeTime;

        private float _targetHealthBar, _targetChangerBar;

        private void Awake()
        {
            _targetHealth.OnHealthChangedEvent += HandleHealthChangedEvent;
            _targetHealthBar = 1;
            _targetChangerBar = 1;
        }

        private void Update()
        {
            _healthBar.localScale = new Vector3(Mathf.Lerp(_healthBar.localScale.x, _targetHealthBar, Time.deltaTime * 8), 1, 1);
            _changerBar.localScale = new Vector3(Mathf.Lerp(_changerBar.localScale.x, _targetChangerBar, Time.deltaTime * 8), 1, 1);
            if (_lastChangeTime + _changerDelay < Time.time)
            {
                _targetChangerBar = _targetHealthBar;
            }
        }

        private void HandleHealthChangedEvent(BigInteger prev, BigInteger current)
        {
            BigInteger value = 10000 * current / _targetHealth.MaxHealthBigInteger;
            float amount = (float)value / 10000;
            if (current < prev)
            {
                _targetHealthBar = amount;
                _lastChangeTime = Time.time;
            }
            else
            {
                _targetHealthBar = amount;
                _targetChangerBar = amount;
                _healthBar.localScale = new Vector3(_targetHealthBar, 1, 1);
                _changerBar.localScale = new Vector3(_targetChangerBar, 1, 1);
            }
        }

        private void OnDestroy()
        {
            _targetHealth.OnHealthChangedEvent -= HandleHealthChangedEvent;
        }
    }
}