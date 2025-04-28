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
        protected EntityStat _statCompo;
        protected LayerMask _whatIsTarget;
        protected Player _player;

        public virtual void Init(Entity owner,SkillSO SO)
        {
            _owner = owner;
            SkillSO = SO;
            _whatIsTarget = LayerMask.GetMask("Enemy");
            _skillCoolTime = SkillSO.coolDown;
            _isPassiveSkill = SkillSO.skillType == SkillType.Passive;
            _isDotSkill = SkillSO.damageType == DamageType.Dot;
            _statCompo = owner.GetCompo<EntityStat>();
            _player = owner as Player;
        }


        public virtual void Update()
        {
            if (_isPassiveSkill == true && CoolTimeCheck() && RangeCheck())
            {
                UseSkill();
            }

            if(_isPassiveSkill == false && _isUseSkill == true)
            {
                UseSkill();
                _isUseSkill = false;
            }
        }

        public virtual bool CoolTimeCheck()
        {
            if(_prevSkillTime + _skillCoolTime < Time.time)
            {
                _prevSkillTime = Time.time;
                return true;
            }
            else
                return false;
        }

        public virtual bool RangeCheck()
        {
            return Physics2D.CircleCast(_owner.transform.position, SkillSO.skillRange, Vector2.zero, 0, _whatIsTarget);
        }

        public float GetCurrentCoolTime()
        {
            //return (_prevSkillTime + _skillCoolTime / _attackSpeed.Value) - Time.time; 
            return (_prevSkillTime + _skillCoolTime) - Time.time; 
        }

        public void SetUseSkill(bool useSkill)
        {
            _isUseSkill = useSkill;
        }

        public abstract void UseSkill();

        public virtual void OnEquipSkill()
        {
            _prevSkillTime = Time.time;
            AddEffect(_owner,SkillSO.equipEffects);
        }

        public virtual void OnUnEquipSkill()
        {
            RemoveEffect(_owner, SkillSO.equipEffects);
        }

        public virtual void UnlockSkill()
        {
            AddEffect(_owner, SkillSO.unlockEffects);
        }

        public abstract Skill Clone();


        public virtual BigInteger DamageCalculation(double playerAttackDamage)
        {
            _currentDamage = (BigInteger)((SkillSO.baseSkillPercent + (SkillSaveManager.Instance.GetItemLevel(SkillSO) * SkillSO.upgradeSkillPercent))/100 * playerAttackDamage);
            Debug.Log(playerAttackDamage);
            float random = Random.Range(0f, 100f);

            if (random < _statCompo.StatDictionary["CriticalChance"].Value)
            {
                return _currentDamage * (BigInteger)(_statCompo.StatDictionary["CriticalDamage"].Value / 100);
            }
            return _currentDamage;
        }

        public void AddEffect(Entity target, List<EffectSO> effectList)
        {
            var statComponent = target.GetCompo<EntityStat>();

            foreach (var effectSO in effectList)
            {
                string effectTypeKey = effectSO.effectType.ToString();
                foreach (var effect in effectSO.effects)
                {
                    if (effect.stat.isBigInteger)
                        statComponent.StatDictionary[effect.stat].AddModify(
                        effectTypeKey,
                        (BigInteger)effect.value,
                        effect.modifyMode,
                        effect.modifyLayer );
                    else
                        statComponent.StatDictionary[effect.stat].AddModify(
                        effectTypeKey,
                        effect.value,
                        effect.modifyMode,
                        effect.modifyLayer
                        );
                    
                    Debug.Log(statComponent.StatDictionary[effect.stat].BigIntValue);
                }
                if (effectSO.isEffectTime)
                {
                    DOVirtual.DelayedCall(effectSO.effectTime, ()=> RemoveEffect(target, effectList));
                }
            }
        }

        public void RemoveEffect(Entity target, List<EffectSO> effectList)
        {
            var statComponent = target.GetCompo<EntityStat>();

            foreach (var effectSO in effectList)
            {
                string effectTypeKey = effectSO.effectType.ToString();

                foreach (var effect in effectSO.effects)
                {
                    statComponent.StatDictionary[effect.stat].RemoveModify(
                        effectTypeKey,
                        effect.modifyLayer
                    );
                }
            }
        }
    }
}
