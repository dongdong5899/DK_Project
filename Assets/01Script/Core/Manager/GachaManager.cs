using DKProject.Combat;
using DKProject.SkillSystem;
using DKProject.Weapon;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject
{
    public class GachaManager : MonoBehaviour
    {
        [SerializeField] private SkillListSO _skillListSO;
        [SerializeField] private WeaponListSO _weaponListSO;

        private Dictionary<Rank, float> rankPercent = new Dictionary<Rank, float>()
        {
            { Rank.Common, 67.3f },
            { Rank.Rare, 16.3f },
            { Rank.Epic, 9.78f },
            { Rank.Unique, 6.52f },
            { Rank.Legendary, 0.1f }
        };

        private float totalPercent = 100;

        public List<T> GachaItem<T>(int gachaCount)
        {
            List<T> gachaList = new List<T>();

            ItemListSO itemListSO = typeof(T) == typeof(SkillSO) ? _skillListSO : _weaponListSO;

            List<ItemSO> itemList = itemListSO.GetList();
            for (int i = 0; i < gachaCount; i++)
            {
                Rank gachaRank = RollRank();

                List<T> rankList = new List<T>();
                for(int j = 0; j < rankList.Count; j++)
                {
                    if (itemList[j].itemRank == gachaRank && itemList[j] is T item)
                    {
                        // skill, weapon 병합 받으면 추가하기 넣을 예정

                        rankList.Add(item);
                    }
                }

                int random = Random.Range(0, rankList.Count);
                gachaList.Add(rankList[random]);
            }
            return gachaList;
        }

        private Rank RollRank()
        {
            float randomValue = Random.Range(0f, totalPercent);

            float cumulative = 0f;
            foreach (var kvp in rankPercent)
            {
                cumulative += kvp.Value;
                if (randomValue <= cumulative)
                    return kvp.Key;
            }

            return Rank.Common;
        }
    }
}
