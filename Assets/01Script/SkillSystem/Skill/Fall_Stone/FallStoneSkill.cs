using UnityEngine;
using DKProject.Core.Pool;

namespace DKProject.SkillSystem.Skills
{
    public class FallStoneSkill : Skill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillprojectileSpeed;

        public override void UseSkill()
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(_owner.transform.position, SkillSO.skillRange, _whatIsTarget);

            FallStone fallStone = PoolManager.Instance.Pop(ProjectilePoolingType.Fall_Stone) as FallStone;

            float randX = Random.Range(_owner.transform.position.x - 5, _owner.transform.position.x + 5);

            fallStone.transform.position = new Vector2(randX, _owner.transform.position.y+10);

            fallStone.Setting(targets[0].transform.position,_skillprojectileSpeed, _whatIsTarget, DamageCalculation((double)_player.GetAttackDamage()), _lifeTime);
        }


        public override Skill Clone()
        {
            return new FallStoneSkill();
        }
    }

}
