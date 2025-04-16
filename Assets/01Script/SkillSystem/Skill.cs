using UnityEngine;
using DKProject.Entities;
using System.Numerics;
using DKProject.Entities.Components;
using Vector2 = UnityEngine.Vector2;
using Random = UnityEngine.Random;

namespace DKProject.SkillSystem.Skill
{
    public abstract class Skill
    {
        public SkillSO SkillSO { get; private set; }
        protected Entity _owner;
        protected float _prevSkillTime;
        protected float _skillCoolTime;
        protected bool _isPassiveSkill;
        protected float _currentCoolTime;
        protected bool _isUseSkill = true;
        protected int _skillLevel = 1;
        protected bool _unlockSkill = false;
        protected BigInteger _currentDamage;
        protected EntityStat _statCompo;
        protected LayerMask _whatIsTarget;

        public virtual void Init(Entity owner,SkillSO SO)
        {
            _owner = owner;
            Debug.Log(_owner);
            SkillSO = SO;
            _whatIsTarget = LayerMask.GetMask("Enemy");
            _skillCoolTime = SkillSO.currentCoolDown;
            _isPassiveSkill = SkillSO.skillType == SkillType.Passive;
            _currentDamage = new BigInteger(SkillSO.currentAttackcoefficient / 100 + _skillLevel*(100-1));
            _statCompo = owner.GetCompo<EntityStat>();
        }


        public virtual void Update()
        {
            Debug.Log(_owner);
            if (_isPassiveSkill == true)
            {
                UseSkill();
            }

            if(_isPassiveSkill == false && _isUseSkill == true && CoolTimeCheck() && RangeCheck())
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
            return Physics2D.CircleCast(_owner.transform.position, SkillSO.currentRange, Vector2.zero, 0, _whatIsTarget);
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
        }

        public virtual void OnUnEquipSkill()
        {

        }
        public abstract Skill Clone();

        public virtual void LevelUpSkill()
        {
            _skillLevel++;
            _currentDamage = 
                new BigInteger((SkillSO.currentAttackcoefficient / 100 + _skillLevel * (100 - 1)));
        }

        public virtual void UnlockSkill()
        {
            _unlockSkill = true;
        }

        public virtual BigInteger ApplyDamage()
        {
            float random = Random.Range(0f, 100f);

            if (random < _statCompo.StatDictionary["CriticalChance"].Value)
            {
                return _currentDamage * new BigInteger((_statCompo.StatDictionary["CriticalDamage"].Value) / 100);
            }
            return _currentDamage;
        }
    }
}
