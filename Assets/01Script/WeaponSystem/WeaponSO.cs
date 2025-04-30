using DKProject.Combat;
using DKProject.EffectSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Weapon
{

    [CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/WeaponSO")]
    public class WeaponSO : ItemSO
    {
        public int weaponIndex;
        public int maxLevel;

        public List<ApplyStatData> increaseStats;
    }
}
