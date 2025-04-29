using DKProject.Combat;
using DKProject.SkillSystem;
using DKProject.Weapon;
using Doryu.JBSave;
using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace DKProject.Core
{
    public class SkillSaveManager: ItemManager
    {
        private string _fileName = "Skill";

        public override bool LevelUpItem(ItemSO itemSO)
        {
            if (!itemDictionary.ContainsKey(itemSO))
                return false;

            if (ResourceData.TryRemoveSkillPoint((uint)GetItemUpgradePrice(itemSO))) // 1은 임시
            {
                ItemData data = itemDictionary[itemSO];
                data.level++;
                itemDictionary[itemSO] = data;

                UpdateItemData(itemSO, data);
                Save();
                OnChangeValue?.Invoke();

                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetSkillRevolutionLevel(SkillSO skillSO)
        {
            if (itemDictionary.TryGetValue(skillSO, out var data))
            {
                return data.revolutionLevel;
            }
            return 0;
        }


        public bool TrySkillRevolution(SkillSO skillSO)
        {
            if (itemDictionary.TryGetValue(skillSO, out var data))
            {
                int skillCountRequired = data.revolutionLevel*5; //수식으로 대체예정
                if (data.count >= skillCountRequired)
                {
                    data.count -= skillCountRequired;
                    data.revolutionLevel++;
                    UpdateItemData(skillSO, data);
                    Save();
                    OnChangeValue?.Invoke();
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        public override BigInteger GetItemUpgradePrice(ItemSO itemSO)
        {
            switch (itemSO.itemRank)
            {
                case Rank.Common:
                    return 1;
                case Rank.Rare:
                    return 1;
                case Rank.Unique:
                    return 2;
                case Rank.Epic:
                    return 3;
                case Rank.Legendary:
                    return 5;
                default:
                    return 0;
            }
        }

    }
}
