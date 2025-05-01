using DKProject.Entities;
using DKProject.SkillSystem;
using DKProject.StatSystem;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


namespace DKProject.EffectSystem
{
    [CreateAssetMenu(fileName = "EffectSO", menuName = "SO/EffectSO")]
    public class EffectSO : ScriptableObject
    {
        public Sprite effectImage;
        public string effectName;
        public string effectDescription;
        public BuffType buffType;
        public BuffTargetType targetType;
        public EffectType effectType;
        public bool isEffectTime;
        public float effectTime;
        public bool isDotDamage;

        public List<Effects> effects;

        [SerializeReference] public Effect effect;


        private void OnEnable()
        {
            if (effect != null) return;
            try
            {
                Type t = Type.GetType($"DKProject.EffectSystem.Skills.{effectType.ToString()}Effect");
                effect = Activator.CreateInstance(t) as Effect;
            }
            catch (Exception e)
            {
                Debug.LogError($"Effect name of {effectType.ToString()} is not exsist");
                Debug.LogException(e);
            }
        }

        public Effect GetEffect(Entity owner)
        {
            effect.Init(owner, this);
            return effect;
        }
    }

    [Serializable]
    public struct ApplyStatData
    {
        public StatElementSO stat;
        public float baseValue;
        public float upgradeValue;
        public EModifyMode modifyMode;
        public EModifyLayer modifyLayer;
    }
}

