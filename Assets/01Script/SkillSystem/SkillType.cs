using UnityEngine;


namespace DKProject.SkillSystem.Skill
{
    public enum SkillType
    {
        Active,
        Passive
    }

    public enum TargetType
    {
        Single,
        Range
    }

    public enum CastType
    {
        InstantCast,
        Casting
    }

    public enum DamageType
    {
        DD,
        DOT
    }

    public enum BuffType
    {
        Buff, Debuff
    }

    public enum BuffTargetType
    {
        Owner, Target
    }

    public enum EffectType
    {

    }

    public enum SkillRank
    {
        Common,Rare,Unique
    }
}

