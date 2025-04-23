using DG.Tweening;
using DKProject.Core.Pool;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class ThrowBombSkill : Skill
    {

        public override void UseSkill()
        {
            Sequence sequence = DOTween.Sequence();

            for (byte i = 0; i < SkillSO.skillCount; i++)
            {
                sequence.AppendCallback(() =>
                {
                    Collider2D[] targets = Physics2D.OverlapCircleAll(_owner.transform.position, SkillSO.skillRange, _whatIsTarget);

                    if (targets.Length == 0) return;

                    ThrowBomb throwBomb = PoolManager.Instance.Pop(ProjectilePoolingType.Throw_Bomb) as ThrowBomb;

                    throwBomb.transform.position = _owner.transform.position;

                    throwBomb.Setting(
                        targets[0].transform.position,
                        _whatIsTarget,
                        DamageCalculation(),
                        SkillSO.lifeTime,
                        SkillSO.skillprojectileSpeed
                    );
                });

                // ∞¢ ∆¯≈∫ ªÁ¿Ãø° 0.2√  µÙ∑π¿Ã
                sequence.AppendInterval(0.2f);
            }
        }

        public override Skill Clone()
        {
            return new ThrowBombSkill();
        }
    }
}

