using DG.Tweening;
using DKProject.Core;
using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class ThrowBombSkill : RangeSkill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;
        [SerializeField] private byte _skillCount;
        public override void UseSkill()
        {
            Sequence sequence = DOTween.Sequence();

            for (byte i = 0; i < _skillCount; i++)
            {
                sequence.AppendCallback(() =>
                {
                    ThrowBomb throwBomb = PoolManager.Instance.Pop(ProjectilePoolingType.Throw_Bomb) as ThrowBomb;

                    throwBomb.transform.position = _owner.transform.position;

                    throwBomb.Setting(
                        _colliders.GetRandomElement().transform.position,
                        _whatIsTarget,
                        DamageCalculation((double)_player.GetAttackDamage()),
                        _lifeTime,
                        _skillProjectileSpeed
                    );
                });

                // ∞¢ ∆¯≈∫ ªÁ¿Ãø° 0.2√  µÙ∑π¿Ã
                sequence.AppendInterval(0.2f);
            }
        }
    }
}

