using DKProject.Combat;
using DKProject.SkillSystem;
using DKProject.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DKProject.Core
{
    [Serializable]
    public struct RankPercent
    {
        public Rank rank;
        public float percent;
    }

    [Serializable]
    public struct LevelRankPercent
    {
        public int level;
        public List<RankPercent> percents;

        public LevelRankPercent(int level)
        {
            this.level = level;
            percents = new List<RankPercent>
            {
                new RankPercent { rank = Rank.Common, percent = 0 },
                new RankPercent { rank = Rank.Rare, percent = 0 },
                new RankPercent { rank = Rank.Epic, percent = 0 },
                new RankPercent { rank = Rank.Unique, percent = 0 },
                new RankPercent { rank = Rank.Legendary, percent = 0 },
            };
        }
    }

    public struct LevelData
    {
        public int level;
        public int count;
        public int needCount;
    }

    public class GachaManager : MonoSingleton<GachaManager>
    {
        public event Action<ItemType> OnChangeGachaType;
        public event Action<LevelData> OnChangeGachaLevel;

        [SerializeField] private SkillListSO _skillListSO;
        [SerializeField] private WeaponListSO _weaponListSO;

        [SerializeField] private List<LevelRankPercent> _levelRankPercentList = new();
        private Dictionary<int, List<RankPercent>> _rankPercent = new Dictionary<int, List<RankPercent>>();
        private Dictionary<Type, LevelData> _gachaLevelDictionary = new Dictionary<Type, LevelData>();

        private float _totalPercent = 100;
        private ItemType _currentGachaType;

        [ContextMenu("ResetPercentList")]
        private void ResetPercentList()
        {
#if UNITY_EDITOR
            _levelRankPercentList.Clear();

            for (int i = 0; i < 10; i++)
            {
                _levelRankPercentList.Add(new LevelRankPercent(i + 1));
            }

            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }

        private void Awake()
        {
            foreach (LevelRankPercent levelRankPercent in _levelRankPercentList)
            {
                _rankPercent[levelRankPercent.level] = levelRankPercent.percents;
            }

            LevelData defaultData =
                new LevelData
                {
                    level = 1,
                    count = 0,
                    needCount = 100
                };
            _gachaLevelDictionary[typeof(SkillSO)] = defaultData;
            _gachaLevelDictionary[typeof(WeaponSO)] = defaultData;
        }

        public Dictionary<T, int> GachaItem<T>(int gachaCount) where T : ItemSO
        {
            Dictionary<T, int> gachaList = new Dictionary<T, int>();

            bool isSkillSO = typeof(T) == typeof(SkillSO);
            ItemListSO itemListSO = isSkillSO ? _skillListSO : _weaponListSO;

            List<ItemSO> itemList = itemListSO.GetList();
            for (int i = 0; i < gachaCount; i++)
            {
                Rank gachaRank = RollRank(_gachaLevelDictionary[typeof(T)].level);

                List<ItemSO> rankList = itemList.Where(item => item.itemRank == gachaRank).ToList();

                ItemSO itemSO = rankList.GetRandomElement();
                if (isSkillSO)
                    SkillSaveManager.Instance.AddItem(itemSO);
                else
                    WeaponSaveManager.Instance.AddItem(itemSO);

                if (gachaList.ContainsKey(itemSO as T))
                {
                    gachaList[itemSO as T]++;
                }
                else
                {
                    gachaList[itemSO as T] = 1;
                }
            }

            GachaLevelUpdate(typeof(T), gachaCount);
            return gachaList;
        }

        private Rank RollRank(int level)
        {
            float randomValue = Random.Range(0f, _totalPercent);

            float cumulative = 0f;
            var list = _rankPercent[level];
            foreach (RankPercent rankPercent in list)
            {
                cumulative += rankPercent.percent;
                if (randomValue <= cumulative)
                    return rankPercent.rank;
            }

            return Rank.Common;
        }

        private void GachaLevelUpdate(Type type, int count)
        {
            var data = _gachaLevelDictionary[type];
            data.count += count;

            if(data.count >= data.needCount)
            {
                data.count = 0;
                data.needCount += 50; // 수식 적용 예정
                data.level++;
            }

            _gachaLevelDictionary[type] = data;
            OnChangeGachaLevel?.Invoke(data);
        }

        public void SetCurrentGachaItem(ItemType itemType)
        {
            _currentGachaType = itemType;
            OnChangeGachaType?.Invoke(itemType);
            OnChangeGachaLevel?.Invoke(_gachaLevelDictionary[_currentGachaType == ItemType.Skill ? typeof(SkillSO) : typeof(WeaponSO)]);
        }
    }
}
