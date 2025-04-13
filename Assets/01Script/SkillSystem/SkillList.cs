using DKProject.Players.Skill;
using System.Collections.Generic;
using UnityEngine;


namespace DKProject.Players.Skill
{
    [CreateAssetMenu(fileName = "SkillList", menuName = "SO/Skill/SkillList")]
    public class SkillList : ScriptableObject
    {
        public List<Skill> skillList;
    }
}

