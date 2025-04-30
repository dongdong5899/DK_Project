using DKProject.Entities.Components;
using DKProject.Entities;
using DKProject.SkillSystem;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Numerics;
using System;
using DKProject.StatSystem;
using DKProject.Entities.Players;

namespace DKProject.EffectSystem
{
    public abstract class Effect
    {
        public EffectSO EffectSO { get; private set; }
        protected Entity _owner;
        protected float _prevDamageTime, _damageCoolTime, _currentCoolTime;
        protected BigInteger _currentDamage;
        protected Player _player;

        public virtual void Init(Entity owner, EffectSO SO)
        {
            _owner = owner;
            EffectSO = SO;
        }

        public virtual void Update()
        {
            if (CoolTimeCheck())
                ApplyDamage();
        }

        public virtual bool CoolTimeCheck()
        {
            if (_prevDamageTime + _damageCoolTime < Time.time)
            {
                _prevDamageTime = Time.time;
                return true;
            }
            else
                return false;
        }

        protected abstract void ApplyDamage();

        public void ApplyEffect(EntityStat stat)
        {
            string effectTypeKey = EffectSO.effectType.ToString();

            foreach (Effects effect in EffectSO.effects)
            {
                if (effect.stat.isBigInteger)
                    stat.StatDictionary[effect.stat].AddModify(
                    effectTypeKey,
                    (BigInteger)effect.value,
                    effect.modifyMode,
                    effect.modifyLayer);
                else
                    stat.StatDictionary[effect.stat].AddModify(
                    effectTypeKey,
                    effect.value,
                    effect.modifyMode,
                    effect.modifyLayer
                    );
            }
        }
        public void RemoveEffect(EntityStat stat)
        {
            string effectTypeKey = EffectSO.effectType.ToString();

            foreach (var effect in EffectSO.effects)
            {
                stat.StatDictionary[effect.stat].RemoveModify(
                    effectTypeKey,
                    effect.modifyLayer
                );
            }
        }

        
    }

    [Serializable]
    public struct Effects
    {
        public StatElementSO stat;
        public EModifyMode modifyMode;
        public EModifyLayer modifyLayer;
        public float value;
    }
}
