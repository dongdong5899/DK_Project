using DKProject.Weapon;

namespace DKProject
{
    public class InvenWeapon : InvenSlot
    {
        public override void UpdateLevel()
        {
            _level.text = $"{WeaponSaveManager.Instance.GetItemLevel(ItemSO)}";
        }
    }
}
