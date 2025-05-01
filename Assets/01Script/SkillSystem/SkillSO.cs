using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DKProject.Entities;
using DKProject.Combat;
using DKProject.EffectSystem;

namespace DKProject.SkillSystem
{
    [CreateAssetMenu(fileName = "SkillSO", menuName = "SO/Skill/SkillSO")]
    public class SkillSO : ItemSO
    {
        [Header("SkillType")]
        public SkillType skillType;
        public TargetType targetType;
        public DamageType damageType;

        [Header("SkillStat")]
        public float coolDown;
        public float baseSkillCoefficient;
        public float upgradeSkillCoefficient;

        [Header("Effect")]
        public List<ApplyStatData> unlockStats;
        public List<ApplyStatData> equipStats;


        [Header("Skill")]
        [SerializeReference] public Skill skill;

        //private void OnEnable()
        //{
        //    if (skill != null) return;
        //    try
        //    {
        //        Type t = Type.GetType($"DKProject.SkillSystem.Skills.{itemClassName}Skill");
        //        skill = Activator.CreateInstance(t) as Skill;
        //    }
        //    catch (Exception e)
        //    { 
        //        Debug.LogError($"Skill name of {itemClassName} is not exsist");
        //        Debug.LogException(e);
        //    }
        //}

        public Skill GetSkill(Entity owner)
        {
            skill.Init(owner, this);
            return skill;
        }
    }
}


