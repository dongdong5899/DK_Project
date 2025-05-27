using DG.Tweening;
using DKProject.Core;
using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class ThrowDodgeBallSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;

        public override void UseSkill()
        {
            ThrowDodgeBall dodgeBall = PoolManager.Instance.Pop(ProjectilePoolingType.Throw_DodgeBall) as ThrowDodgeBall;

            int ranIdx = Random.Range(0, 100);
            float randX = ranIdx > 50 ? 5 : -5;

            dodgeBall.transform.position = new Vector2(randX, _owner.transform.position.y + 3);

            dodgeBall.Setting(_colliders.GetRandomElement().transform.position, _skillProjectileSpeed, _whatIsTarget, DamageCalculation((double)_player.GetAttackDamage()), _lifeTime);
        }
    }
}
