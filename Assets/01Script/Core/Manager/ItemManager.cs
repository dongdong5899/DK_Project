using DKProject.Combat;
using DKProject.EffectSystem;
using DKProject.Entities.Components;
using DKProject.SkillSystem;
using DKProject.Weapon;
using Doryu.JBSave;
using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace DKProject.Core
{
    public class ItemManager : MonoSingleton<ItemManager>
    {
        public Dictionary<ItemSO, ItemData> itemDictionary;
        public ItemSave save;
        public Action OnChangeValue;
        [SerializeField] private ItemListSO _itemList;
        private string _fileName;
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
            itemDictionary = new Dictionary<ItemSO, ItemData>();
            ItemDictionarySet();
            DontDestroyOnLoad(this.gameObject);
        }

        protected override void CreateInstance()
        {
            base.CreateInstance();
            Initialized();
        }

        private void ItemDictionarySet()
        {
            itemDictionary.Clear();
            if (save.itemDataBase == null) return;

            foreach (var pair in save.itemDataBase)
            {
                if (!itemDictionary.ContainsKey(pair.first))
                {
                    itemDictionary.Add(pair.first, pair.second);
                }
            }
        }

        private void Load()
        {
            save = new ItemSave();
            if (save.LoadJson(_fileName) == false)
            {
                save.ResetData();
                Init(_itemList);
            }


            OnChangeValue?.Invoke();
        }

        public void Save()
        {
            save.SaveJson(_fileName);
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
                save.itemDataBase.Add(new Pair<ItemSO, ItemData>(itemSO, itemdata));
            }
        }


        

        protected void UpdateItemData(ItemSO itemSO, ItemData data)
        {
            for (int i = 0; i < save.itemDataBase.Count; i++)
            {
                if (save.itemDataBase[i].first == itemSO)
                {
                    save.itemDataBase[i] = new Pair<ItemSO, ItemData>(itemSO, data);
                    return;
                }
            }
        }

        public void AddItem(ItemSO itemSO)
        {
            if (!itemDictionary.ContainsKey(itemSO))
                return;

            ItemData data = itemDictionary[itemSO];
            data.count++;
            if (!itemDictionary[itemSO].isUnlock)
            {
                data.isUnlock = true;
                if (TryGetComponent(out SkillSO skillSO))
                {
                    skillSO.skill.UnlockSkill();
                }
            }

            itemDictionary[itemSO] = data;

            UpdateItemData(itemSO, data);
            Save();
            OnChangeValue?.Invoke();
        }


        public bool GetIsUnlocked(ItemSO itemSO)
        {
            if (itemDictionary.TryGetValue(itemSO, out var data))
            {
                return data.isUnlock;
            }
            return false;
        }

        public int GetItemLevel(ItemSO itemSO)
        {
            if (itemDictionary.TryGetValue(itemSO, out var data))
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

        public void AddStat(ItemSO item, List<ApplyStatData> statList,EntityStat stat)
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
