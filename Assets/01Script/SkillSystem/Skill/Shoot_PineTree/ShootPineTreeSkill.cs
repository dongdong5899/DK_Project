using DG.Tweening;
using DKProject.Core;
using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class ShootPineTreeSkill : RangeSkill
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
                    ShootGomuLine shootGomuLine = PoolManager.Instance.Pop(ProjectilePoolingType.Shooting_GomuLine) as ShootGomuLine;

                    shootGomuLine.transform.position = _owner.transform.position;

                    shootGomuLine.Setting(
                        _colliders.GetRandomElement().transform.position,
                        _whatIsTarget,
                        DamageCalculation((double)_player.GetAttackDamage()),
                        _lifeTime,
                        _skillProjectileSpeed
                    );
                });

                sequence.AppendInterval(0.2f);
            }
        }
    }
}
