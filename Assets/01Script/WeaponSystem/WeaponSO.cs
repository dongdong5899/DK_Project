using DKProject.Combat;
using DKProject.SkillSystem;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DKProject.Weapon
{
    [Serializable]
    public struct ApplyStatData
    {
        public StatElementSO statSo;
        public float applyValue;
        public float IncreaseValue;
    }

    [CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/WeaponSO")]
    public class WeaponSO : ItemSO
    {
        public int weaponIndex;
        public int maxLevel;

        public List<ApplyStatData> increaseStats;
    }
}
