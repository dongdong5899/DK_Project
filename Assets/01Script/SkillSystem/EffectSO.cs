using DKProject.StatSystem;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace DKProject.SkillSystem
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

        public List<Effects> effects;
    }

    [Serializable]
    public struct Effects
    {
        public StatElementSO stat;
        public EModifyMode modifyMode;
        public EModifyLayer modifyLayer;
        public float value;
    }
}

