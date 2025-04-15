using DKProject.Entities.Components;
using DKProject.Entities.Players;
using DKProject.Entities;
using DKProject.SkillSystem.Skill;
using UnityEditor.EditorTools;
using UnityEngine;
using DKProject.Cores.Pool;

namespace DKProject.SkillSystem.Skill
{
    public class FallStoneSkill : Skill
    {
        private Player _player;
        private EntityRenderer _renderer;
        private float _detectingDistance = 20;
        private LayerMask _whatIsTarget;
        private float _attckSpeed = 10f;

        public override void Init(Entity owner, SkillSO skillSO)
        {
            base.Init(owner, skillSO);
            _whatIsTarget = LayerMask.GetMask("Enemy");
            //_player = PlayerManager.Instance.Player;
            _renderer = _player.GetCompo<EntityRenderer>(true);
        }

        public override void UseSkill()
        {
            Collider2D target = Physics2D.OverlapCircle(_owner.transform.position, _detectingDistance, _whatIsTarget);

            FallStone fallStone = PoolManager.Instance.Pop(ProjectileType.Fall_Stone) as FallStone;

            fallStone.Setting(target.transform.position, _attckSpeed);
        }

        

        public override Skill Clone()
        {
            Skill skill = new FallStoneSkill();
            return skill;
        }
    }

}
