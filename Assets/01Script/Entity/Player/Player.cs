using DKProject.Entities.Components;
using DKProject.Entities.Enemies;
using DKProject.SkillSystem.Skill;
using DKProject.StatSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DKProject.Entities.Players
{
    public class Player : Entity
    {
        private EntityState _entityState;
        private EntityMover _entityMover;
        private PlayerRenderer _entityRenderer;
        private EntityStat _entityStat;
        private StatElement _attackSpeedStat;
        private StatElement _attackDamageStat;
        private float _lastAttackTime;
        [SerializeField] private SkillSO _testSkill;

        public bool IsCanAttack()
            => _lastAttackTime + 1f / _attackSpeedStat.Value < Time.time;
        public void CheckAttackTime()
            => _lastAttackTime = Time.time;
        public void Attack(Enemy enemy)
        {
            enemy.GetCompo<EntityHealth>().ApplyDamage(_attackDamageStat.BigIntValue);
        }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void AfterInitComponents()
        {
            base.AfterInitComponents();
            _entityState = GetCompo<EntityState>();
            _entityMover = GetCompo<EntityMover>();
            _entityRenderer = GetCompo<PlayerRenderer>();
            _entityStat = GetCompo<EntityStat>();
            _attackSpeedStat = _entityStat.StatDictionary[StatName.AttackSpeed];
            _attackDamageStat = _entityStat.StatDictionary[StatName.AttackDamage];
        }

        protected override void DisposeComponents()
        {
            base.DisposeComponents();
        }

        private void Update()
        {
            if (Keyboard.current.tKey.isPressed)
            {
                GetCompo<PlayerSkillSystem>().EquipSkill(_testSkill.GetSkill(this), 0);
                List<Skill> skillList = new List<Skill>();
                _testSkill.GetSkill(this).Init(this,_testSkill);
                skillList.Add(_testSkill.GetSkill(this));
                GetCompo<PlayerSkillSystem>().SetSlot(skillList);
            }
        }
    }
}