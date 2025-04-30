using UnityEngine;
using DKProject.Core.Pool;
using DKProject.Core;

namespace DKProject.SkillSystem.Skills
{
    public class FallStoneSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;

        public override void UseSkill()
        {
            FallStone fallStone = PoolManager.Instance.Pop(ProjectilePoolingType.Fall_Stone) as FallStone;

            int ranIdx = Random.Range(0, 100);
            float randX = ranIdx > 50 ? 5 : -5;

            fallStone.transform.position = new Vector2(randX, _owner.transform.position.y + 10);

            fallStone.Setting(_colliders.GetRandomElement().transform.position, _skillProjectileSpeed, _whatIsTarget, DamageCalculation((double)_player.GetAttackDamage()), _lifeTime);
        }
    }

}
