using System;
using System.Numerics;
using UnityEngine;

namespace DKProject.Entities.Components
{
    public class EntityHealth : MonoBehaviour, IEntityComponent
    {
        [SerializeField] private string _health = "100";
        public BigInteger MaxHealthBigInteger { get; private set; }
        public BigInteger CurrentHealthBigInteger { get; private set; }

        public event Action<BigInteger, BigInteger> OnHealthChangedEvent;

        public void Initialize(Entity entity)
        {
            MaxHealthBigInteger = BigInteger.Parse(_health);
            CurrentHealthBigInteger = MaxHealthBigInteger;
        }

        public void ApplyDamage(BigInteger bigInteger)
        {
            BigInteger prev = CurrentHealthBigInteger;
            CurrentHealthBigInteger -= bigInteger;
            OnHealthChangedEvent?.Invoke(prev, CurrentHealthBigInteger);
            Debug.Log(bigInteger.ToString());
        }
    }
}