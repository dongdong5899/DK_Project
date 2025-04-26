using DKProject.SkillSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Weapon
{
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/WeaponSO")]
    public class WeaponSO : ScriptableObject
    {
        public Rank weaponRank;
        public Sprite weaponIcon;
        public string weaponName;
        public string weaponID;
        public string weaponDescription;
        public List<Pair<StatElementSO, float>> increaseStats;
    }
}
