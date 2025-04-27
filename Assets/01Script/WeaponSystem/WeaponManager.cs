using DKProject.Core;
using Doryu.JBSave;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject.Weapon
{
    public class WeaponManager : MonoSingleton<WeaponManager>
    {
        public event Action OnChangeValue;

        public Dictionary<WeaponSO, WeaponData> weaponDictionary;

        public WeaponSave save;
        [SerializeField] private WeaponListSO _weaponList;
        private string fileName = "Weapon";
        private int _needMergeCount = 5;

        protected override void CreateInstance()
        {
            base.CreateInstance();
            Load();
            weaponDictionary = new Dictionary<WeaponSO, WeaponData>();
            WeaponDictionarySet();
            DontDestroyOnLoad(this.gameObject);
        }

        public void Init(WeaponListSO list)
        {
            foreach (WeaponSO weaponSO in list.GetList())
            {
                WeaponData weapondata = new WeaponData();
                weapondata.isUnlock = false;
                weapondata.weaponLevel = 1;
                weapondata.weaponCount = 0;
                save.weaponDataBase.Add(new Pair<WeaponSO, WeaponData>(weaponSO, weapondata));
            }
        }

        public void Save()
        {
            save.SaveJson<WeaponSave>(fileName);
        }

        private void Load()
        {
            save = new WeaponSave();
            if (!save.LoadJson<WeaponSave>(fileName))
            {
                save.ResetData();
                Init(_weaponList);
            }

            OnChangeValue?.Invoke();
        }

        private void WeaponDictionarySet()
        {
            weaponDictionary.Clear();
            if (save.weaponDataBase == null) return;

            foreach (var pair in save.weaponDataBase)
            {
                if (!weaponDictionary.ContainsKey(pair.first))
                {
                    weaponDictionary.Add(pair.first, pair.second);
                }
            }
        }

        public void AddWeapon(WeaponSO weaponSO)
        {
            if (!weaponDictionary.ContainsKey(weaponSO))
                return;

            WeaponData data = weaponDictionary[weaponSO];
            data.weaponCount++;
            if (!weaponDictionary[weaponSO].isUnlock)
                data.isUnlock = true;
            weaponDictionary[weaponSO] = data;

            UpdateWeaponData(weaponSO, data);
            Save();
            OnChangeValue?.Invoke();
        }

        public bool LevelUpWeapon(WeaponSO weaponSO)
        {
            if (!weaponDictionary.ContainsKey(weaponSO))
                return false;

            if(ResourceData.TryRemoveResource(ResourceType.Gold, 1)) // 1ю╨ юс╫ц
            {
                WeaponData data = weaponDictionary[weaponSO];
                data.weaponLevel++;
                weaponDictionary[weaponSO] = data;

                UpdateWeaponData(weaponSO, data);
                Save();
                OnChangeValue?.Invoke();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void MergeAllWeapon()
        {
            foreach (var weapon in weaponDictionary.Keys.ToList())
            {
                int canMergeCount = GetCanMergeCount(weapon);
                if (canMergeCount > 0)
                {
                    MergeWeapon(weapon, canMergeCount, true);
                }
            }

            Save();
            OnChangeValue?.Invoke();
        }

        public void MergeWeapon(WeaponSO weaponSO, int mergingCount, bool isAllMerge = false)
        {
            if (!weaponDictionary.ContainsKey(weaponSO))
                return;
            if (int.Parse(weaponSO.itemID.Substring(1)) == weaponDictionary.Count)
                return;

            int count = weaponDictionary[weaponSO].weaponCount;

            WeaponData curWeapondata = weaponDictionary[weaponSO];
            curWeapondata.weaponCount -= mergingCount * _needMergeCount;

            weaponDictionary[weaponSO] = curWeapondata;
            UpdateWeaponData(weaponSO, curWeapondata);

            WeaponSO nextWeaponSO = FindNextWeapon(weaponSO);
            if (nextWeaponSO != null)
            {
                WeaponData nextWeaponData = weaponDictionary[nextWeaponSO];
                nextWeaponData.weaponCount += mergingCount;
                if (!nextWeaponData.isUnlock)
                    nextWeaponData.isUnlock = true;

                weaponDictionary[nextWeaponSO] = nextWeaponData;
                UpdateWeaponData(nextWeaponSO, nextWeaponData);
            }

            if (!isAllMerge)
            {
                Save();
                OnChangeValue?.Invoke();
            }
        }

        private WeaponSO FindNextWeapon(WeaponSO currentWeapon)
        {
            int id = currentWeapon.weaponIndex;
            id++;

            foreach(var weapon in weaponDictionary.Keys)
            {
                if(weapon.weaponIndex == id)
                {
                    return weapon;
                }
            }
            return null;
        }

        public int GetCanMergeCount(WeaponSO weaponSO)
        {
            return weaponDictionary[weaponSO].weaponCount / _needMergeCount;
        }

        public bool GetIsUnlocked(WeaponSO weaponSO)
        {
            if (weaponDictionary.TryGetValue(weaponSO, out var data))
            {
                return data.isUnlock;
            }
            return false;
        }

        public int GetWeaponLevel(WeaponSO weaponSO)
        {
            if (weaponDictionary.TryGetValue(weaponSO, out var data))
            {
                return data.weaponLevel;
            }
            return 0;
        }

        private void UpdateWeaponData(WeaponSO weaponSO, WeaponData data)
        {
            for (int i = 0; i < save.weaponDataBase.Count; i++)
            {
                if (save.weaponDataBase[i].first == weaponSO)
                {
                    save.weaponDataBase[i] = new Pair<WeaponSO, WeaponData>(weaponSO, data);
                    return;
                }
            }
        }
    }
}
