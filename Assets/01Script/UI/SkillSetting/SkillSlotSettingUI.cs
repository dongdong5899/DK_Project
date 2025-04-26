using DKProject.Core;
using DKProject.SkillSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DKProject.UI
{
    public class SkillSlotSettingUI : Button
    {
        private int _index;
        [SerializeField] private Image _icon;

        public void Init(int index)
        {
            _index = index;
        }

        public void SetSkill(Skill skill)
        {
            if (skill != null)
            {
                _icon.sprite = skill.SkillSO.icon;
                _icon.color = Color.white;
            }
            else
            {
                _icon.color = Color.clear;
            }
        }
    }
}
