using DKProject.Core;
using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace DKProject.Entities.Components
{
    public class EntityHealth : MonoBehaviour, IEntityComponent, IAfterInitable
    {
        [SerializeField] private DamageText _damageText;
        [SerializeField] private string _health = "100";
        public BigInteger MaxHealthBigInteger { get; private set; }
        public BigInteger CurrentHealthBigInteger { get; private set; }
        public bool IsDead { get; private set; }

        public event Action<BigInteger, BigInteger> OnHealthChangedEvent;

        private Entity _entity;

        private List<DamageText> _damageTextList = new List<DamageText>();

        public void Initialize(Entity entity)
        {
            MaxHealthBigInteger = BigInteger.Parse(_health);
            _entity = entity;
        }

        public void AfterInit()
        {
            CurrentHealthBigInteger = MaxHealthBigInteger;
            OnHealthChangedEvent?.Invoke(MaxHealthBigInteger, MaxHealthBigInteger);
            IsDead = false;
        }

        public void Dispose()
        {
            IsDead = true;
        }

        public void ApplyDamage(BigInteger bigInteger)
        {
            if (IsDead) return;

            BigInteger prev = CurrentHealthBigInteger;
            CurrentHealthBigInteger -= bigInteger;

            DamageText damageText = Instantiate(_damageText, transform.position, UnityEngine.Quaternion.identity);
            // 위치잡기
            Vector3 spawnPos = transform.position;
            bool isFull = true;
            for (int i = 0; i < _damageTextList.Count; i++)
            {
                if (_damageTextList[i] == null)
                {
                    _damageTextList[i] = damageText;
                    spawnPos += Vector3.up * i * 0.25f;
                    isFull = false;
                    break;
                }
            }
            if (isFull)
            {
                spawnPos += Vector3.up * _damageTextList.Count * 0.4f;
                _damageTextList.Add(damageText);
                if (_damageTextList.Count == 5) _damageTextList.Clear();
            }
            spawnPos += Vector3.right * Random.Range(-0.2f, 0.2f);
            damageText.Init(spawnPos, bigInteger.ParseNumber(), Color.yellow);

            if (CurrentHealthBigInteger < 0)
            {
                CurrentHealthBigInteger = 0;
                IsDead = true;
                _entity.OnDie();
            }
            OnHealthChangedEvent?.Invoke(prev, CurrentHealthBigInteger);
        }
    }
}