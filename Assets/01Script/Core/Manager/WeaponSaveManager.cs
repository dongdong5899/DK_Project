using DKProject.Combat;
using DKProject.Core;
using System.Linq;
using System.Numerics;

namespace DKProject.Weapon
{
    public class WeaponSaveManager : ItemManager
    {
        private int _needMergeCount = 5;

        public override bool LevelUpItem(ItemSO itemSO)
        {
            if (!_itemDictionary.ContainsKey(itemSO))
                return false;

            if (ResourceData.TryRemoveResource(ResourceType.Gold, GetItemUpgradePrice(itemSO))) // 1은 임시
            {
                ItemData data = _itemDictionary[itemSO];
                data.level++;
                _itemDictionary[itemSO] = data;

                UpdateItemData(itemSO, data);
                Save();
                OnValueChanged?.Invoke();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void MergeAllWeapon()
        {
            foreach (var weapon in _itemDictionary.Keys.ToList())
            {
                int canMergeCount = GetCanMergeCount(weapon as WeaponSO);
                if (canMergeCount > 0)
                {
                    MergeWeapon(weapon, canMergeCount, true);
                }
            }

            Save();
            OnValueChanged?.Invoke();
        }

        public void MergeWeapon(ItemSO weaponSO, int mergingCount, bool isAllMerge = false)
        {
            if (!_itemDictionary.ContainsKey(weaponSO))
                return;
            if (int.Parse(weaponSO.itemClassName.Substring(1)) == _itemDictionary.Count)
                return;

            int count = _itemDictionary[weaponSO].count;

            ItemData curWeapondata = _itemDictionary[weaponSO];
            curWeapondata.count -= mergingCount * _needMergeCount;

            _itemDictionary[weaponSO] = curWeapondata;
            UpdateItemData(weaponSO, curWeapondata);

            WeaponSO nextWeaponSO = FindNextWeapon(weaponSO);
            if (nextWeaponSO != null)
            {
                ItemData nextWeaponData = _itemDictionary[nextWeaponSO];
                nextWeaponData.count += mergingCount;
                if (!nextWeaponData.isUnlock)
                    nextWeaponData.isUnlock = true;

                _itemDictionary[nextWeaponSO] = nextWeaponData;
                UpdateItemData(nextWeaponSO, nextWeaponData);
            }

            if (!isAllMerge)
            {
                Save();
                OnValueChanged?.Invoke();
            }
        }

        private WeaponSO FindNextWeapon(ItemSO currentWeapon)
        {
            WeaponSO weaponSO = currentWeapon as WeaponSO;
            int id = weaponSO.weaponIndex;
            id++;

            foreach (WeaponSO weapon in _itemDictionary.Keys)
            {

                if (weapon.weaponIndex == id)
                {
                    return weapon;
                }
            }
            return null;
        }

        public int GetCanMergeCount(WeaponSO weaponSO)
        {
            return _itemDictionary[weaponSO].count / _needMergeCount;
        }


        public override BigInteger GetItemUpgradePrice(ItemSO itemSO)
        {
            return 10; //식으로 대체
        }
    }
}
