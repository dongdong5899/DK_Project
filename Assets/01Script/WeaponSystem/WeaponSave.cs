using DKProject.Weapon;
using Doryu.JBSave;
using System;
using System.Collections.Generic;

namespace DKProject.Weapon
{
    public class WeaponSave : ISavable<WeaponSave>
    {
        public List<Pair<WeaponSO, WeaponData>> weaponDataBase;

        public WeaponSave()
        {
            weaponDataBase = new List<Pair<WeaponSO, WeaponData>>();
        }

        public void OnLoadData(WeaponSave classData)
        {
            if (classData == null) return;

            weaponDataBase = classData.weaponDataBase;
        }

        public void OnSaveData(string savedFileName)
        {

        }

        public void ResetData()
        {
            weaponDataBase = new List<Pair<WeaponSO, WeaponData>>();
        }
    }

    [Serializable]
    public struct WeaponData
    {
        public bool isUnlock;
        public int weaponLevel;
        public int weaponCount;
    }
}
