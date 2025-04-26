using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class FollowTrashCanSkill : Skill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _speed;
        public override Skill Clone()
        {
            return new FollowTrashCanSkill();
        }

        public override void UseSkill()
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(_owner.transform.position, SkillSO.skillRange, _whatIsTarget);

            if (targets.Length == 0) return;

            FollowTrashCan shootGomuLine = PoolManager.Instance.Pop(ProjectilePoolingType.FollowTrashCan) as FollowTrashCan;

            shootGomuLine.transform.position = _owner.transform.position;

            shootGomuLine.Setting(
                targets[0].transform,
                _whatIsTarget,
                DamageCalculation((double)_player.GetAttackDamage()),
                _lifeTime,
                _speed
            );
        }
    }
}
