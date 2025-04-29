using DKProject.SkillSystem;
using System.Collections.Generic;
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
    }

    
}

