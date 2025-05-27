using DKProject.Core.Pool;
using DKProject.Core;
using UnityEngine;
using Doryu.JBSave;

namespace DKProject.SkillSystem.Skills
{
    public class ShootBounceBallSkill : RangeSkill
    {
        [SerializeField] private float _skillProjectileSpeed;
        private IPoolable _shootBounceBall;

        

        public override void OnEquipSkill()
        {
            base.OnEquipSkill();

            if (RangeCheck())
            {
                ShootBounceBall shootBounceBall = PoolManager.Instance.Pop(ProjectilePoolingType.Shoot_BounceBall) as ShootBounceBall;

                shootBounceBall.transform.position = _owner.transform.position;

                shootBounceBall.Setting(
                    _owner,
                    _colliders.GetRandomElement().transform.position,
                    _whatIsTarget,
                    DamageCalculation((double)_player.GetAttackDamage()),
                    _skillProjectileSpeed
                );
                _shootBounceBall = shootBounceBall;
            }
        }

        public override void OnUnEquipSkill()
        {
            base.OnUnEquipSkill();
            _shootBounceBall.Push();
        }

        public override void UseSkill()
        {
        }
    }
}
