using DKProject.Combat;
using DKProject.EffectSystem;
using DKProject.Entities.Components;
using DKProject.SkillSystem;
using Doryu.JBSave;
using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace DKProject.Core
{
    public class ItemManager : MonoSingleton<ItemManager>
    {
        protected Dictionary<ItemSO, ItemData> _itemDictionary;
        protected ItemSave _saveData;
        public Action OnValueChanged;
        [SerializeField] protected ItemListSO _itemList;

        private string _fileName;
        private bool _isInitialized;

        private void Awake()
        {
            Initialized();
            _fileName = GetType().Name;
        }

        protected override void CreateInstance()
        {
            base.CreateInstance();
            Initialized();
        }

        protected void Initialized()
        {
            if (_isInitialized) return;

            _isInitialized = true;
            Load();
            _itemDictionary = new Dictionary<ItemSO, ItemData>();
            ItemDictionarySet();
            if (Instance == this)
                DontDestroyOnLoad(gameObject);
        }

        private void ItemDictionarySet()
        {
            _itemDictionary.Clear();
            if (_saveData.itemDataBase == null) return;

            foreach (var pair in _saveData.itemDataBase)
            {
                if (!_itemDictionary.ContainsKey(pair.first))
                {
                    _itemDictionary.Add(pair.first, pair.second);
                }
            }
        }

        private void Load()
        {
            _saveData = new ItemSave();
            if (_saveData.LoadJson(_fileName) == false)
            {
                _saveData.ResetData();
                Init(_itemList);
            }


            OnValueChanged?.Invoke();
        }

        public void Save()
        {
            _saveData.SaveJson(_fileName);
        }


        public void Init(ItemListSO itemList)
        {
            foreach (ItemSO itemSO in itemList.GetList())
            {
                ItemData itemdata = new ItemData();
                itemdata.isUnlock = false;
                itemdata.level = 1;
                itemdata.count = 0;
                itemdata.revolutionLevel = 1;
                _saveData.itemDataBase.Add(new Pair<ItemSO, ItemData>(itemSO, itemdata));
            }
        }


        

        protected void UpdateItemData(ItemSO itemSO, ItemData data)
        {
            for (int i = 0; i < _saveData.itemDataBase.Count; i++)
            {
                if (_saveData.itemDataBase[i].first == itemSO)
                {
                    _saveData.itemDataBase[i] = new Pair<ItemSO, ItemData>(itemSO, data);
                    return;
                }
            }
        }

        public void AddItem(ItemSO itemSO)
        {
            if (!_itemDictionary.ContainsKey(itemSO))
                return;

            ItemData data = _itemDictionary[itemSO];
            data.count++;
            if (!_itemDictionary[itemSO].isUnlock)
            {
                data.isUnlock = true;
                if (TryGetComponent(out SkillSO skillSO))
                {
                    skillSO.skill.UnlockSkill();
                }
            }
            _itemDictionary[itemSO] = data;

            UpdateItemData(itemSO, data);
            Save();
            OnValueChanged?.Invoke();
        }


        public bool GetIsUnlocked(ItemSO itemSO)
        {
            if (_itemDictionary.TryGetValue(itemSO, out var data))
            {
                return data.isUnlock;
            }
            return false;
        }

        public int GetItemLevel(ItemSO itemSO)
        {
            if (_itemDictionary.TryGetValue(itemSO, out var data))
            {
                return data.level;
            }
            return 0;
        }

        public virtual bool LevelUpItem(ItemSO itemSO)
        {
            return true;
        }

        public virtual BigInteger GetItemUpgradePrice(ItemSO itemSO)
        {
            return 0;
        }

        public void AddStat(ItemSO item, List<ApplyStatData> statList, EntityStat stat)
        {
            foreach (var increaseStat in statList)
            {
                string effectTypeKey = item.itemClassName.ToString();
                if (increaseStat.stat.isBigInteger)
                    stat.StatDictionary[increaseStat.stat].AddModify(
                    effectTypeKey,
                    (BigInteger)increaseStat.baseValue + (BigInteger)increaseStat.upgradeValue * GetItemLevel(item),
                    increaseStat.modifyMode,
                    increaseStat.modifyLayer);
                else
                    stat.StatDictionary[increaseStat.stat].AddModify(
                    effectTypeKey,
                    increaseStat.baseValue + increaseStat.upgradeValue * GetItemLevel(item),
                    increaseStat.modifyMode,
                    increaseStat.modifyLayer
                    );

                Debug.Log(stat.StatDictionary[increaseStat.stat].BigIntValue);
            }
        }

        public void RemoveStat(ItemSO item, List<ApplyStatData> statList, EntityStat stat)
        {
            foreach (var increaseStat in statList)
            {
                string effectTypeKey = item.itemClassName.ToString();
                stat.StatDictionary[increaseStat.stat].RemoveModify(
                    effectTypeKey,
                    increaseStat.modifyLayer
                );
            }
        }

    }
}
