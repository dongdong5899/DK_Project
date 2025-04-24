using DKProject.SkillSystem;
using Doryu.JBSave;
using System;
using System.Collections.Generic;

namespace DKProject.Core
{
    public class SkillSave : ISavable<SkillSave>
    {
        public List<Pair<SkillSO, SkillData>> skillDataBase;

        public SkillSave()
        {
            skillDataBase = new List<Pair<SkillSO, SkillData>> ();
        }

        public void OnLoadData(SkillSave classData)
        {
            if (classData == null) return;

            skillDataBase = classData.skillDataBase;
        }

        public void OnSaveData(string savedFileName)
        {
            
        }

        public void ResetData()
        {
            skillDataBase = new List<Pair<SkillSO, SkillData>>();
        }
    }

    [Serializable]
    public struct SkillData
    {
        public bool isUnlock;
        public int skillLevel;
        public int skillCount;
        public int skillRevolutionLevel;
    }
}
