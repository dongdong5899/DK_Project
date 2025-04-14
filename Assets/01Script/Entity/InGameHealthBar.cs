using DKProject.Entities.Components;
using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace DKProject.Entities
{
    public class InGameHealthBar : MonoBehaviour
    {
        [SerializeField] private EntityHealth _targetHealth;
        [SerializeField] private Transform _healthBar, _changerBar;

        private void Awake()
        {
            _targetHealth.OnHealthChangedEvent += HandleHealthChangedEvent;
        }

        private void HandleHealthChangedEvent(BigInteger prev, BigInteger current)
        {
            BigInteger asd;
            if (current == 0)
            {
                asd = int.MaxValue;
            }
            else
            {
                asd = 1000 * _targetHealth.MaxHealthBigInteger / current;
            }
            float value = (float)asd / 1000;
            _healthBar.localScale = new Vector3(1f / value, 1, 1);
            _changerBar.localScale = new Vector3(1f / value, 1, 1);
        }

        private void OnDestroy()
        {
            _targetHealth.OnHealthChangedEvent -= HandleHealthChangedEvent;
        }
    }
}