using DKProject.Entities.Components;
using DKProject.Entities.Players;
using DKProject.Entities;
using UnityEngine;
using DKProject.Cores.Pool;
using DKProject.Combat;
using DKProject.Cores;

namespace DKProject.SkillSystem.Skill
{
    public class FallStoneSkill : Skill
    {
        

        private Player _player;
        private EntityRenderer _renderer;
        private float _detectingDistance = 20;
        private LayerMask _whatIsTarget;

        public override void Init(Entity owner, SkillSO skillSO)
        {
            base.Init(owner, skillSO);
            _whatIsTarget = LayerMask.GetMask("Enemy");
        }

        public override void UseSkill()
        {
            Collider2D target = Physics2D.OverlapCircle(_owner.transform.position, _detectingDistance, _whatIsTarget);

            FallStone fallStone = PoolManager.Instance.Pop(ProjectilePoolingType.Fall_Stone) as FallStone;

            fallStone.Setting(target.transform.position, _whatIsEnemy,SkillSO);
        }





        public override Skill Clone()
        {
            Skill skill = new FallStoneSkill();
            return skill;
        }
    }

}
