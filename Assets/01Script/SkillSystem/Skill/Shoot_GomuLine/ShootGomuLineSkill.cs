using DG.Tweening;
using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class ShootGomuLineSkill : Skill
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _skillProjectileSpeed;
        [SerializeField] private byte _skillCount;

        public override Skill Clone()
        {
            return new ShootGomuLineSkill();
        }

        public override void UseSkill()
        {
            Sequence sequence = DOTween.Sequence();

            for (byte i = 0; i < _skillCount; i++)
            {
                sequence.AppendCallback(() =>
                {
                    Collider2D[] targets = Physics2D.OverlapCircleAll(_owner.transform.position, SkillSO.skillRange, _whatIsTarget);

                    if (targets.Length == 0) return;

                    ShootGomuLine shootGomuLine = PoolManager.Instance.Pop(ProjectilePoolingType.Shooting_GomuLine) as ShootGomuLine;

                    shootGomuLine.transform.position = _owner.transform.position;

                    shootGomuLine.Setting(
                        targets[0].transform.position,
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
