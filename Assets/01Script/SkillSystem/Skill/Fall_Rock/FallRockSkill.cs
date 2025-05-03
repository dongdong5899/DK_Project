using DKProject.Core.Pool;
using DKProject.Core;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class FallRockSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;

        public override void UseSkill()
        {
            FallRock fallRock = PoolManager.Instance.Pop(ProjectilePoolingType.Fall_Rock) as FallRock;

            int ranIdx = Random.Range(0, 100);
            float randX = ranIdx > 50 ? 5 : -5;

            fallRock.transform.position = new Vector2(randX, _owner.transform.position.y + 10);

            fallRock.Setting(_colliders.GetRandomElement().transform.position, _skillProjectileSpeed, _whatIsTarget, DamageCalculation((double)_player.GetAttackDamage()), _lifeTime);
        }
    }
}
