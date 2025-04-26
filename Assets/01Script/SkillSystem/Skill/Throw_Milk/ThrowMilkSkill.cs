using DG.Tweening;
using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class ThrowMilkSkill : Skill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;
        [SerializeField] private byte _skillCount;


        public override Skill Clone()
        {
            if (SkillSO.skill == null || SkillSO.skill.GetType() != typeof(ThrowMilkSkill))
            {
                SkillSO.skill = new ThrowMilkSkill();
            }
            return SkillSO.skill;
        }

        public override void UseSkill()
        {

            Collider2D[] targets = Physics2D.OverlapCircleAll(_owner.transform.position, SkillSO.skillRange, _whatIsTarget);

            ThrowMilk throwMilk = PoolManager.Instance.Pop(ProjectilePoolingType.Throw_Milk) as ThrowMilk;

            int ranIdx = Random.Range(0, 100);
            float randX = ranIdx > 50 ? 5 : -5;

            throwMilk.transform.position = new Vector2(randX, _owner.transform.position.y + 5);

            throwMilk.Setting(targets[0].transform.position, _skillProjectileSpeed, _whatIsTarget, DamageCalculation((double)_player.GetAttackDamage()), _lifeTime);
        }
    }
}
