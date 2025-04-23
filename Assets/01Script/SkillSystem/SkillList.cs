using Doryu.CustomAttributes;
using System.Collections.Generic;
using UnityEngine;


namespace DKProject.SkillSystem
{
    [CreateAssetMenu(fileName = "SkillList", menuName = "SO/Skill/SkillList")]
    public class SkillList : ScriptableObject
    {
        [VisibleInspectorSO]
        [SerializeField] private List<SkillSO> _skillList;

        public List<SkillSO> GetList() => _skillList;
    }
}

