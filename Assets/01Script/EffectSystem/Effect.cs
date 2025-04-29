using DKProject.Entities.Components;
using DKProject.Entities;
using DKProject.SkillSystem;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Numerics;
using System;
using DKProject.StatSystem;

namespace DKProject.EffectSystem
{
    public abstract class Effect
    {
        public EffectSO EffectSO { get; private set; }
        protected Entity _owner;
        protected BigInteger _currentDamage;
        protected EntityStat _statCompo;
        protected float _currentCoolTime,_effectCoolTime = 0.2f;
        public abstract Effect Clone();


        //public virtual BigInteger DamageCalculation(double playerAttackDamage)
        //{
        //    _currentDamage = (BigInteger)((SkillSO.baseSkillPercent + (SkillSaveManager.Instance.GetItemLevel(SkillSO) * SkillSO.upgradeSkillPercent)) / 100 * playerAttackDamage);
        //    Debug.Log(playerAttackDamage);
        //    float random = Random.Range(0f, 100f);

        //    if (random < _statCompo.StatDictionary["CriticalChance"].Value)
        //    {
        //        return _currentDamage * (BigInteger)(_statCompo.StatDictionary["CriticalDamage"].Value / 100);
        //    }
        //    return _currentDamage;
        //}

        public virtual void Init(EffectSO SO)
        {
            EffectSO = SO;
        }

        public virtual void Update()
        {
            if (!EffectSO.isDotDamage) return;

            if(_currentCoolTime + _effectCoolTime < Time.time)
            {
                ApplyDamage();
            }
        }

        private void ApplyDamage()
        {

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
