using DKProject.SkillSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Weapon
{
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/Weapon/WeaponSO")]
    public class WeaponSO : ScriptableObject, IComparable<WeaponSO>
    {
        public string weaponID;
        public string weaponName;
        public Sprite weaponIcon;
        public Rank weaponRank;
        [TextArea]
        public string weaponDescription;

        public List<Pair<StatElementSO, float>> increaseStats;


        public int CompareTo(WeaponSO other)
        {
            if (other == null) 
                return 1;

            int thisID = int.Parse(weaponID.Substring(1));
            int otherID = int.Parse(other.weaponID.Substring(1));

            return thisID.CompareTo(otherID);
        }
    }
}
