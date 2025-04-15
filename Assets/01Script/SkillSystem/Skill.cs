using UnityEngine;
using DKProject.Entities;
using System;

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
        [SerializeField] protected LayerMask _whatIsEnemy;
        protected bool _isUseSkill = false;
        protected int _skillLevel = 1;
        protected bool _unlockSkill = false;
        public event Action<Skill> OnSkillEvolution;

        public virtual void Init(Entity owner,SkillSO SO)
        {
            _owner = owner;
            this.SkillSO = SO;

            _skillCoolTime = SkillSO.currentCoolDown;
            _isPassiveSkill = SkillSO.skillType == SkillType.Passive;
        }


        public virtual void Update()
        {
            if (_isPassiveSkill == true && CoolTimeCheck() && RangeCheck())
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
            //if(_prevSkillTime + _skillCoolTime / _attackSpeed.Value < Time.time)
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
            return Physics2D.CircleCast(_owner.transform.position, SkillSO.currentRange, Vector2.zero, 0, _whatIsEnemy);
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
            SkillSO.currentSkillLevel++;
        }

        public virtual void UnlockSkill()
        {
            _unlockSkill = true;
        }
    }
}
