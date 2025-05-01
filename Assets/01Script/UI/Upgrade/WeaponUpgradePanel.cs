using DKProject.SkillSystem;
using DKProject.UI;
using DKProject.Weapon;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DKProject
{
    public class WeaponUpgradePanel : ToggleUI
    {
        public override string Key => nameof(WeaponUpgradePanel);

        [SerializeField] private WeaponListSO _weaponList;
        private InvenSlot[] _invenSkills;

        protected override void Awake()
        {
            base.Awake();
            Close();

            _invenSkills = GetComponentsInChildren<InvenSlot>();
            List<WeaponSO> waeponList = _weaponList.GetList().OfType<WeaponSO>().ToList();
            int skillCount = waeponList.Count;
            for (int i = 0; i < skillCount; i++)
            {
                InvenSlot prev = i - 1 < 0 ? null : _invenSkills[i - 1];
                InvenSlot next = i + 1 >= skillCount ? null : _invenSkills[i + 1];
                _invenSkills[i].Init(prev, next, waeponList[i]);
            }
        }

        public override void Open()
        {
            ActiveElement(true);
        }

        public override void Close()
        {
            ActiveElement(false);
        }
    }
}
