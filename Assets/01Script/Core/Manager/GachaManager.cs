using DKProject.Combat;
using DKProject.SkillSystem;
using DKProject.Weapon;
using System;
using System.Collections.Generic;
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

    public class GachaManager : MonoBehaviour
    {
        public event Action OnChangeValue;

        [SerializeField] private SkillListSO _skillListSO;
        [SerializeField] private WeaponListSO _weaponListSO;

        [SerializeField] private List<LevelRankPercent> _levelRankPercentList = new();
        private Dictionary<int, List<RankPercent>> _rankPercent;

        private float _totalPercent = 100;
        private int _gachaLevel = 1;
        private int _gachaCount = 0;
        private int _needGachaCount = 100; // 임시

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
            foreach(LevelRankPercent levelRankPercent in _levelRankPercentList)
            {
                _rankPercent[levelRankPercent.level] = levelRankPercent.percents;
            }
        }

        public List<T> GachaItem<T>(int gachaCount)
        {
            List<T> gachaList = new List<T>();

            ItemListSO itemListSO = typeof(T) == typeof(SkillSO) ? _skillListSO : _weaponListSO;

            List<ItemSO> itemList = itemListSO.GetList();
            for (int i = 0; i < gachaCount; i++)
            {
                Rank gachaRank = RollRank();

                List<T> rankList = new List<T>();
                for (int j = 0; j < rankList.Count; j++)
                {
                    if (itemList[j].itemRank == gachaRank && itemList[j] is T item)
                    {
                        ItemManager.Instance.AddItem(itemList[j]);

                        rankList.Add(item);
                    }
                }

                int random = Random.Range(0, rankList.Count);
                gachaList.Add(rankList[random]);
            }

            _gachaCount += gachaCount;
            UpdateGachaLevel();
            return gachaList;
        }

        private Rank RollRank()
        {
            float randomValue = Random.Range(0f, _totalPercent);

            float cumulative = 0f;
            var list = _rankPercent[_gachaLevel];
            foreach (RankPercent rankPercent in list)
            {
                cumulative += rankPercent.percent;
                if (randomValue <= cumulative)
                    return rankPercent.rank;
            }

            return Rank.Common;
        }

        private void UpdateGachaLevel()
        {
            if (_gachaCount >= _needGachaCount)
            {
                _gachaLevel++;
                _gachaCount -= _needGachaCount;
                _needGachaCount += 50; // 증가 수식 적용 예정
            }

            OnChangeValue?.Invoke();
        }
    }
}
