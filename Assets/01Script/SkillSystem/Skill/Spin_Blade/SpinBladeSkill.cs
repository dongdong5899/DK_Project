using DG.Tweening;
using DKProject.Core.Pool;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.SkillSystem.Skills
{
    public class SpinBladeSkill : Skill
    {
        private List<IPoolable> _spinBlades;
        [SerializeField] private float _projectileCount;
        [SerializeField] private float _spinSpeed;
        [SerializeField] private float _radius;
        public override void UseSkill()
        {
        }


        public override void OnEquipSkill()
        {
            base.OnEquipSkill();
            Sequence sequence = DOTween.Sequence();
            float angleOffset = 360f / _projectileCount;

            for (int i = 0; i < _projectileCount; i++)
            {
                sequence.AppendCallback(() =>
                {
                    SpinBlade spinBlade = PoolManager.Instance.Pop(ProjectilePoolingType.Spin_Blade) as SpinBlade;
                    spinBlade.transform.SetParent(_owner.transform);
                    _spinBlades.Add(spinBlade);
                    float initialAngle = angleOffset * i;
                    spinBlade.Setting(_owner.transform,
                        _spinSpeed,
                        DamageCalculation((double)_player.GetAttackDamage()),
                        _radius,
                        initialAngle,_whatIsTarget);
                });
                sequence.AppendInterval(0.5f);
            }
        }


        public override void OnUnEquipSkill()
        {
            base.OnUnEquipSkill();
            for(byte i = 0; i < _spinBlades.Count; i++)
            {
                _spinBlades[i].Push();
            }
        }
    }
}
