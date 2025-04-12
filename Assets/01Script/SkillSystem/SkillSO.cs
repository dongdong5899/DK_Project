using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DKProject.Entities;

namespace DKProject.Players.Skill
{
    [CreateAssetMenu(fileName = "SkillSO", menuName = "SO/Skill/SkillSO")]
    public class SkillSO : ScriptableObject
    {
        [Header("Skiil")]
        public string skillName;
        public Sprite icon;
        [TextArea]
        public string itemDescription;
        public bool useCooldown;

        [Header("SkillType")]
        public SkillType skillType;
        public TargetType targetType;
        public CastType castType;
        public DamageType damageType;

        [Header("SkillStat")]
        public float castTime;
        public byte currentCoolDown;
        public byte currentskillCount;
        public byte currentRange;
        public float currentAreaRadius;

        [Header("SkillLevel")]
        public int baseSkillLevel;
        public int currentSkillLevel;

        [Header("Effect")]
        public List<Effect> effects;


        private Skill _skill;
        private void OnEnable()
        {
            try
            {
                Type t = Type.GetType($"{skillName}Skill");
                _skill = Activator.CreateInstance(t) as Skill;
            }
            catch (Exception e)
            {
                Debug.LogError($"Skill name of {skillName} is not exsist");
                Debug.LogException(e);
            }
        }

        public Skill GetSkill(Entity owner)
        {
            Skill skill = _skill.Clone();
            skill.Init(this, owner);
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


