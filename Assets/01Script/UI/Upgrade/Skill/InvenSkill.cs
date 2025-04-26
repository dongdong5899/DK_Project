using DKProject.Core;
using DKProject.SkillSystem;
using DKProject.UI;
using DKProject.Weapon;
using UnityEngine;

namespace DKProject
{
    public class InvenSkill : InvenSlot
    {
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void HandleClickEvent()
        {
            DataPopUpUI dataPopUpUI = UIManager.Instance.OpenUI(nameof(DataPopUpUI)) as DataPopUpUI;
            dataPopUpUI.SetItem(this);
        }

        public override void UpdateLevel()
        {
            if(ItemSO.itemType == ItemType.Skill)
            {
                _level.text = $"{SkillSaveManager.Instance.GetSkillLevel(ItemSO as SkillSO)}";
            }
            if (ItemSO.itemType == ItemType.Weapon)
            {
                _level.text = $"{WeaponManager.Instance.GetWeaponLevel(ItemSO as WeaponSO)}";
            }
        }
    }
}
