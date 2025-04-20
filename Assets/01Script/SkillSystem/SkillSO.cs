using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DKProject.Entities;

namespace DKProject.SkillSystem.Skill
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
        public float currentLifeTime;
        public float currentCoolDown;
        public byte currentskillCount;
        public float currentRange;
        public float currentAreaRadius;
        public float currentAttackcoefficient;
        public float currentProjectileSpeed;

        [Header("Effect")]
        public List<Effect> effects;

        public Skill skill;

        private void OnEnable()
        {
            try
            {
                Type t = Type.GetType($"DKProject.SkillSystem.Skill.{skillID}Skill");
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
            return skill;
        }
    }


    [Serializable]
    public struct Effect
    {
        public BuffType buffType;
        public BuffTargetType targetType;
        public EffectType effectType;
        public float effectTime;
    }
}


