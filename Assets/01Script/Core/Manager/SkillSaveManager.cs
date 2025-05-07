using DKProject.Combat;
using DKProject.SkillSystem;
using System.Numerics;

namespace DKProject.Core
{
    public class SkillSaveManager : ItemManager<SkillSaveManager>
    {
        public override bool LevelUpItem(ItemSO itemSO)
        {
            if (!_itemDictionary.ContainsKey(itemSO))
                return false;

            if (ResourceData.TryRemoveSkillPoint((uint)GetItemUpgradePrice(itemSO))) // 1은 임시
            {
                ItemData data = _itemDictionary[itemSO];
                data.level++;
                _itemDictionary[itemSO] = data;
                SkillSO skillSO = itemSO as SkillSO;
                if (skillSO)
                {
                    skillSO.skill.AddStat(skillSO.equipStats);
                    skillSO.skill.AddStat(skillSO.unlockStats);
                }
                UpdateItemData(itemSO, data);
                Save();
                OnValueChanged?.Invoke();

                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetSkillRevolutionLevel(SkillSO skillSO)
        {
            if (_itemDictionary.TryGetValue(skillSO, out var data))
            {
                return data.revolutionLevel;
            }
            return 0;
        }


        public bool TrySkillRevolution(SkillSO skillSO)
        {
            if (_itemDictionary.TryGetValue(skillSO, out var data))
            {
                int skillCountRequired = data.revolutionLevel * 5; //수식으로 대체예정
                if (data.count >= skillCountRequired)
                {
                    data.count -= skillCountRequired;
                    data.revolutionLevel++;
                    UpdateItemData(skillSO, data);
                    Save();
                    OnValueChanged?.Invoke();
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
