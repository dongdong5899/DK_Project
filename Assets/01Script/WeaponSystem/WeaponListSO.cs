using Doryu.CustomAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Weapon
{
    [CreateAssetMenu(fileName = "WeaponList", menuName = "SO/Weapon/WeaponList")]
    public class WeaponListSO : ScriptableObject
    {
        [VisibleInspectorSO]
        [SerializeField] private List<WeaponSO> _weaponList;

        public List<WeaponSO> GetList() => _weaponList;
    }
}
