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
        public Rank skillRank;
        [TextArea]
        public string skillDescription;

        [Header("SkillType")]
        public SkillType skillType;
        public TargetType targetType;
        public DamageType damageType;

        [Header("SkillStat")]
        public float coolDown;
        public float skillRange;
        public float skillAreaRadius;
        public float baseSkillPercent;
        public float upgradeSkillPercent;

        [Header("Effect")]
        public List<EffectSO> unlockEffects;
        public List<EffectSO> equipEffects;
        

        [SerializeReference] public Skill skill;

        private void OnEnable()
        {
            if (skill != null) return;
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
            skill.Init(owner, this);
            return skill;
        }
    }
}


