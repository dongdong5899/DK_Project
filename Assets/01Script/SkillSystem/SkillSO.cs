using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DKProject.Entities;

namespace DKProject.SkillSystem
{
    [CreateAssetMenu(fileName = "SkillSO", menuName = "SO/Skill/SkillSO")]
    public class SkillSO : ScriptableObject
    {
        [Header("Skiil")]
        public string skillID;
        public string skillName;
        public Sprite icon;
        public SkillRank skillRank;
        [TextArea]
        public string skillDescription;

        [Header("SkillType")]
        public SkillType skillType;
        public TargetType targetType;
        public DamageType damageType;

        [Header("SkillStat")]
        public float lifeTime;
        public float coolDown;
        public byte skillCount;
        public float skillRange;
        public float skillAreaRadius;
        public float baseSkillPercent;
        public float upgradeSkillPercent;
        public float skillprojectileSpeed;
        public float skillDotAttackMinus;

        [Header("Effect")]
        public List<EffectSO> unlockEffects;
        public List<EffectSO> equipEffects;
        public List<EffectSO> buffEffects;

        public Skill skill;

        private void OnEnable()
        {
            try
            {
                Type t = Type.GetType($"DKProject.SkillSystem.Skills.{skillID}Skill");
                skill = Activator.CreateInstance(t) as Skill;
            }
            catch (Exception e)
            { 
                Debug.LogError($"Skill name of {skillID} is not exsist");
                Debug.LogException(e);
            }
        }

        public Skill GetSkill(Entity owner)
        {
            Skill curSkill = skill.Clone();
            curSkill.Init(owner, this);
            return curSkill;
        }
    }
}


