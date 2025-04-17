using DKProject.Entities.Components;
using DKProject.Entities.Players;
using DKProject.Entities;
using UnityEngine;
using DKProject.Cores.Pool;

namespace DKProject.SkillSystem.Skill
{
    public class FallStoneSkill : Skill
    {
        

        public override void Init(Entity owner, SkillSO skillSO)
        {
            base.Init(owner, skillSO);
        }

        public override void UseSkill()
        {
            Debug.Log("UseSkill");
            Collider2D[] targets = Physics2D.OverlapCircleAll(_owner.transform.position, SkillSO.currentRange, _whatIsTarget);

            FallStone fallStone = PoolManager.Instance.Pop(ProjectilePoolingType.Fall_Stone) as FallStone;

            float randX = Random.Range(_owner.transform.position.x - 5, _owner.transform.position.x + 5);

            fallStone.transform.position = new Vector2(randX, _owner.transform.position.y+10);

            fallStone.Setting(targets[0].transform.position,SkillSO.currentProjectileSpeed, _whatIsTarget, DamageCalculation());
        }


        public override Skill Clone()
        {
            Skill skill = new FallStoneSkill();
            return skill;
        }
    }

}
