using UnityEngine;
using DKProject.Entities;
using System.Numerics;
using DKProject.Entities.Components;
using Vector2 = UnityEngine.Vector2;
using Random = UnityEngine.Random;
using DKProject.Entities.Players;
using DG.Tweening;
using DKProject.Core;
using System;
using System.Collections.Generic;
using DKProject.EffectSystem;

namespace DKProject.SkillSystem
{
    [Serializable]
    public abstract class Skill
    {
        public SkillSO SkillSO { get; private set; }
        protected Entity _owner;
        protected float _prevSkillTime;
        protected float _skillCoolTime;
        protected bool _isPassiveSkill,_isDotSkill;
        protected float _currentCoolTime;
        protected bool _isUseSkill = true;
        protected BigInteger _currentDamage;
        protected EntityStat _entityStat;
        protected EntityEffect _entityEffect;
        [SerializeField] protected LayerMask _whatIsTarget;
        protected Player _player;

        public virtual void Init(Entity owner,SkillSO SO)
        {
            _owner = owner;
            SkillSO = SO;
            _skillCoolTime = SkillSO.coolDown;
            _isPassiveSkill = SkillSO.skillType == SkillType.Passive;
            _isDotSkill = SkillSO.damageType == DamageType.Dot;
            _entityStat = owner.GetCompo<EntityStat>();
            _entityEffect = owner.GetCompo<EntityEffect>();
            _player = owner as Player;
        }


        public virtual void Update()
        {
            if (_isPassiveSkill == true && IsUsable())
            {
                UseSkill();
            }
        }

        private bool CoolTimeCheck()
        {
            if(_prevSkillTime + _skillCoolTime < Time.time)
            {
                _prevSkillTime = Time.time;
                return true;
            }
            else
                return false;
        }

        public virtual bool IsUsable()
        {
            return CoolTimeCheck();
        }

        public float GetCurrentCoolTime()
        {
            //return (_prevSkillTime + _skillCoolTime / _attackSpeed.Value) - Time.time; 
            return (_prevSkillTime + _skillCoolTime) - Time.time; 
        }

        public void SetUseSkill(bool useSkill)
        {
            if (_isPassiveSkill) return;
            UseSkill();
        }

        public abstract void UseSkill();

        public virtual void OnEquipSkill()
        {
            _prevSkillTime = Time.time;
            SkillSaveManager.Instance.AddStat(SkillSO,SkillSO.equipStats,_entityStat);
        }

        public virtual void OnUnEquipSkill()
        {
            SkillSaveManager.Instance.RemoveStat(SkillSO, SkillSO.equipStats, _entityStat);
        }

        public virtual void UnlockSkill()
        {
            SkillSaveManager.Instance.AddStat(SkillSO, SkillSO.unlockStats, _entityStat);
        }

        public virtual BigInteger DamageCalculation(double playerAttackDamage)
        {
            _currentDamage = (BigInteger)((SkillSO.baseSkillCoefficient + (SkillSaveManager.Instance.GetItemLevel(SkillSO) * SkillSO.upgradeSkillCoefficient))/100 * playerAttackDamage);
            Debug.Log(playerAttackDamage);
            float random = Random.Range(0f, 100f);

            if (random < _entityStat.StatDictionary["CriticalChance"].Value)
            {
                return _currentDamage * (BigInteger)(_entityStat.StatDictionary["CriticalDamage"].Value / 100);
            }
            return _currentDamage;
        }


        public void AddEffect(List<EffectSO> effectList)
        {
            foreach (EffectSO effect in effectList)
            {
                _entityEffect.ApplyEffect(effect.effectType);
            }
        }

        public void RemoveEffect(List<EffectSO> effectList)
        {
            foreach (EffectSO effect in effectList)
            {
                _entityEffect.RemoveEffect(effect.effectType);
            }
        }
    }
}
