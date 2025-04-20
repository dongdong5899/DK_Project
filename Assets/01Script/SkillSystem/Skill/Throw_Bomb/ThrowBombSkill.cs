using DKProject.Cores.Pool;
using DKProject.Entities;
using UnityEngine;

namespace DKProject.SkillSystem.Skill
{
    public class ThrowBombSkill : Skill
    {

        public override void Init(Entity owner, SkillSO SO)
        {
            base.Init(owner, SO);
        }


        public override void UseSkill()
        {
            for(byte i = 0; i < SkillSO.currentskillCount; i++)
            {
                Collider2D[] targets = Physics2D.OverlapCircleAll(_owner.transform.position, SkillSO.currentRange, _whatIsTarget);

                ThrowBomb throwBomb = PoolManager.Instance.Pop(ProjectilePoolingType.Throw_Bomb) as ThrowBomb;

                throwBomb.transform.position = _owner.transform.position;

                throwBomb.Setting(_owner.transform.position, targets[0].transform.position, _whatIsTarget, DamageCalculation(), 45, SkillSO.currentLifeTime);
            }
        }

        public override Skill Clone()
        {
            return new ThrowBombSkill();
        }
    }
}

