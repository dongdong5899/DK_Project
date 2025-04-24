using DKProject.SkillSystem;
using Doryu.JBSave;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Core
{
    public class SkillManager: MonoSingleton<SkillManager>
    {
        public SkillSave save;
        public Dictionary<SkillSO, SkillData> skillDictionary;
        public event Action OnChangeValue;
        [SerializeField] private SkillListSO _skillList;
        private string fileName = "Skill";
        public SkillManager()
        {
            Load();
            skillDictionary = new Dictionary<SkillSO, SkillData>();
            SkillDictionarySet();
        }

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public void Init(SkillListSO list)
        {
            foreach(SkillSO skillSO in list.GetList())
            {
                SkillData skilldata = new SkillData();
                skilldata.isUnlock = false;
                skilldata.skillLevel = 1;
                save.skillDataBase.Add(new Pair<SkillSO, SkillData>(skillSO, skilldata));
            }
        }

        public void Save()
        {
            save.SaveJson<SkillSave>(fileName);
        }

        private void Load()
        {
            save = new SkillSave();
            if (save.LoadJson<SkillSave>(fileName) == false)
            {
                save.ResetData();
                Init(_skillList);
            }
            

            OnChangeValue?.Invoke();
        }

        private void SkillDictionarySet()
        {
            skillDictionary.Clear();
            if (save.skillDataBase == null) return;

            foreach (var pair in save.skillDataBase)
            {
                if (!skillDictionary.ContainsKey(pair.first))
                {
                    skillDictionary.Add(pair.first, pair.second);
                }
            }
        }

        public void UnlockSkill(SkillSO skillName)
        {
            SkillData data = new SkillData();
            if (skillDictionary.ContainsKey(skillName))
            {
                data = skillDictionary[skillName];
                data.isUnlock = true;
                skillDictionary[skillName] = data;
            }
            else
            {
                return;
            }

            UpdateSkillData(skillName,data);
            Save();
            OnChangeValue?.Invoke();
        }

        public void LevelUpSkill(SkillSO skillName)
        {
            SkillData data = new SkillData();
            if (skillDictionary.ContainsKey(skillName))
            {
                data = skillDictionary[skillName];
                data.skillLevel++;
                skillDictionary[skillName] = data;
            }
            else
            {
                return;
            }

            UpdateSkillData(skillName, data);
            Save();
            OnChangeValue?.Invoke();
        }

        public bool GetIsUnlocked(SkillSO skillName)
        {
            if (skillDictionary.TryGetValue(skillName, out var data))
            {
                return data.isUnlock;
            }
            return false;
        }

        public int GetSkillLevel(SkillSO skillSO)
        {
            if (skillDictionary.TryGetValue(skillSO, out var data))
            {
                return data.skillLevel;
            }
            return 0;
        }

        private void UpdateSkillData(SkillSO skillName, SkillData data)
        {
            for (int i = 0; i < save.skillDataBase.Count; i++)
            {
                if (save.skillDataBase[i].first == skillName)
                {
                    save.skillDataBase[i] = new Pair<SkillSO, SkillData>(skillName, data);
                    return;
                }
            }
        }


    }
}
