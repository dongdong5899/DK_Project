using DKProject.Core;
using DKProject.SkillSystem;
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

        public bool OnLoadData(WeaponSave classData)
        {
            if (classData == null) return false;

            foreach (var pair in classData.weaponDataBase)
            {
                if (pair.first == null)
                {
                    weaponDataBase = new List<Pair<WeaponSO, WeaponData>>();
                    return false;
                }
            }
            weaponDataBase = classData.weaponDataBase;

            return true;
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
