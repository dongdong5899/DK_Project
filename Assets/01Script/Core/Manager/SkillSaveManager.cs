using DKProject.SkillSystem;
using DKProject.UI;
using Doryu.JBSave;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Core
{
    public class SkillSaveManager: MonoSingleton<SkillSaveManager>
    {
        public SkillSave save;
        public Dictionary<SkillSO, SkillData> skillDictionary;
        public event Action OnChangeValue;
        [SerializeField] private SkillListSO _skillList;
        private string _fileName = "Skill";
        private bool _isInitialized;

        private void Awake()
        {
            Initialized();
        }
        private void Initialized()
        {
            if (_isInitialized) return;

            _isInitialized = true;
            Load();
            skillDictionary = new Dictionary<SkillSO, SkillData>();
            SkillDictionarySet();
            DontDestroyOnLoad(this.gameObject);
        }
        protected override void CreateInstance()
        {
            base.CreateInstance();
            Initialized();
        }

        public void Init(SkillListSO list)
        {
            foreach(SkillSO skillSO in list.GetList())
            {
                SkillData skilldata = new SkillData();
                skilldata.isUnlock = false;
                skilldata.skillLevel = 1;
                skilldata.skillCount = 0;
                skilldata.skillRevolutionLevel = 1;
                save.skillDataBase.Add(new Pair<SkillSO, SkillData>(skillSO, skilldata));
            }
        }

        public void Save()
        {
            save.SaveJson(_fileName);
        }

        private void Load()
        {
            save = new SkillSave();
            if (save.LoadJson(_fileName) == false)
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

        public int GetSkillRevolutionLevel(SkillSO skillSO)
        {
            if (skillDictionary.TryGetValue(skillSO, out var data))
            {
                return data.skillRevolutionLevel;
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

        public bool TrySkiilLevelUp(SkillSO skillSO)
        {
            uint skillPointRequired = 1; // 1 부분 수식으로 바꿀예정
            if (skillDictionary.TryGetValue(skillSO, out var data))
            {
                data.skillLevel++;
            }
            return ResourceData.TryRemoveSkillPoint(skillPointRequired);
        }

        public bool TrySkillRevolution(SkillSO skillSO)
        {
            if (skillDictionary.TryGetValue(skillSO, out var data))
            {
                int skillCountRequired = data.skillRevolutionLevel*5; //수식으로 대체예정
                if (data.skillCount >= skillCountRequired)
                {
                    data.skillCount -= skillCountRequired;
                    data.skillRevolutionLevel++;
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

    }
}
