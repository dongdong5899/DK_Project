using DG.Tweening;
using DKProject.Core;
using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class ThrowMilkSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;
        [SerializeField] private byte _skillCount;

        public override void UseSkill()
        {
            ThrowMilk throwMilk = PoolManager.Instance.Pop(ProjectilePoolingType.Throw_Milk) as ThrowMilk;

            int ranIdx = Random.Range(0, 100);
            float randX = ranIdx > 50 ? 5 : -5;

            throwMilk.transform.position = new Vector2(randX, _owner.transform.position.y + 5);

            throwMilk.Setting(_colliders.GetRandomElement().transform.position, _skillProjectileSpeed, _whatIsTarget, DamageCalculation((double)_player.GetAttackDamage()), _lifeTime);
        }
    }
}
