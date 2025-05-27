using DKProject.Core;
using UnityEngine;

namespace DKProject
{
    public class InvenSkill : InvenSlot
    {
        public override void UpdateLevel()
        {
            _level.text = $"{SkillSaveManager.Instance.GetItemLevel(ItemSO)}";
        }
    }
}
