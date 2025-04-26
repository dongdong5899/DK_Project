using DKProject.Combat;
using DKProject.SkillSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Weapon
{
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/WeaponSO")]
    public class WeaponSO : ItemSO
    {
        public List<Pair<StatElementSO, float>> increaseStats;
    }
}
