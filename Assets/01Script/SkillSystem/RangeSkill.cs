using DKProject.SkillSystem;
using UnityEngine;

namespace DKProject.SkillSystem
{
    public abstract class RangeSkill : Skill
    {
        [SerializeField] protected float _radius;

        protected Collider2D[] _colliders;

        private bool RangeCheck()
        {
            _colliders = Physics2D.OverlapCircleAll(_player.transform.position, _radius, _whatIsTarget);
            return _colliders.Length > 0;
        }

        protected Collider2D GetTargetForDistance(bool isNearTarget)
        {
            Collider2D nearTarget = null;
            if (_colliders.Length > 0)
            {
                nearTarget = _colliders[0];
                float lastDistance = Vector2.Distance(_player.transform.position, nearTarget.transform.position);

                for (int i = 0; i < _colliders.Length; i++)
                {
                    float distance = Vector2.Distance(_player.transform.position, _colliders[i].transform.position);
                    if ((distance < lastDistance) ^ !isNearTarget)
                    {
                        nearTarget = _colliders[i];
                        lastDistance = distance;
                    }
                }
            }
            return nearTarget;
        }

        public override bool IsUsable()
        {
            return base.IsUsable() && RangeCheck();
        }
    }
}
