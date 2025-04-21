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
        public float effectTime;
    }
}

