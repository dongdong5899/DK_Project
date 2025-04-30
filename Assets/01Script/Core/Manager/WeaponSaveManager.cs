using DKProject.Combat;
using DKProject.Core;
using Doryu.JBSave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

namespace DKProject.Weapon
{
    public class WeaponSaveManager : ItemManager
    {
        private string fileName = "Weapon";
        private int _needMergeCount = 5;

        public override bool LevelUpItem(ItemSO itemSO)
        {
            if (!itemDictionary.ContainsKey(itemSO))
                return false;

            if(ResourceData.TryRemoveResource(ResourceType.Gold, GetItemUpgradePrice(itemSO))) // 1은 임시
            {
                ItemData data = itemDictionary[itemSO];
                data.level++;
                itemDictionary[itemSO] = data;

                UpdateItemData(itemSO, data);
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
            foreach (var weapon in itemDictionary.Keys.ToList())
            {
                int canMergeCount = GetCanMergeCount(weapon as WeaponSO);
                if (canMergeCount > 0)
                {
                    MergeWeapon(weapon, canMergeCount, true);
                }
            }

            Save();
            OnChangeValue?.Invoke();
        }

        public void MergeWeapon(ItemSO weaponSO, int mergingCount, bool isAllMerge = false)
        {
            if (!itemDictionary.ContainsKey(weaponSO))
                return;
            if (int.Parse(weaponSO.itemClassName.Substring(1)) == itemDictionary.Count)
                return;

            int count = itemDictionary[weaponSO].count;

            ItemData curWeapondata = itemDictionary[weaponSO];
            curWeapondata.count -= mergingCount * _needMergeCount;

            itemDictionary[weaponSO] = curWeapondata;
            UpdateItemData(weaponSO, curWeapondata);

            WeaponSO nextWeaponSO = FindNextWeapon(weaponSO);
            if (nextWeaponSO != null)
            {
                ItemData nextWeaponData = itemDictionary[nextWeaponSO];
                nextWeaponData.count += mergingCount;
                if (!nextWeaponData.isUnlock)
                    nextWeaponData.isUnlock = true;

                itemDictionary[nextWeaponSO] = nextWeaponData;
                UpdateItemData(nextWeaponSO, nextWeaponData);
            }

            if (!isAllMerge)
            {
                Save();
                OnChangeValue?.Invoke();
            }
        }

        private WeaponSO FindNextWeapon(ItemSO currentWeapon)
        {
            WeaponSO weaponSO = currentWeapon as WeaponSO;
            int id = weaponSO.weaponIndex;
            id++;

            foreach(WeaponSO weapon in itemDictionary.Keys)
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
            return itemDictionary[weaponSO].count / _needMergeCount;
        }


        public override BigInteger GetItemUpgradePrice(ItemSO itemSO)
        {
            return 10; //식으로 대체
        }

    }
}
