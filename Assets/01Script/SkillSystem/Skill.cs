using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using DKProject.Entities;

namespace DKProject.Players.Skill
{
    public abstract class Skill
    {
        public SkillSO skillSO { get; private set; }
        protected Entity _owner;
        //protected StatElement _attackSpeed;
        protected float _prevSkillTime;
        protected float _skillCoolTime;
        protected bool _useCoolTime;
        protected bool _isPassiveSkill;

        public virtual void Init(SkillSO skillSO, Entity owner)
        {
            _owner = owner;
            this.skillSO = skillSO;

            _skillCoolTime = skillSO.currentCoolDown;
            _useCoolTime = skillSO.useCooldown;
            _isPassiveSkill = skillSO.skillType == SkillType.Passive;
            //_attackSpeed = PlayerManager.Instance.Player.GetCompo<StatCompo>().GetElement("AttackSpeed");
        }

        public virtual void UseSkill()
        {

        }

        public abstract Skill Clone();

    }
}
