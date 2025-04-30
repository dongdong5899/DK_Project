using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI
{
    public class DataPopUpPanel : MonoUI
    {
        [SerializeField] private Image _spriteRenderer;
        [SerializeField] private TextMeshProUGUI _name, _description, _level, _stat, _equipText, _upgradeText;
        [SerializeField] private Button _upgrade, _sub, _equip;

        public void SetData(Sprite sprite, string name, string description, Action upgrade, Action sub, Action equip)
        {
            _spriteRenderer.sprite = sprite;
            _name.text = name;
            _description.text = description;
            _upgrade.OnClickEvent = upgrade;
            _sub.OnClickEvent = sub;
            _equip.OnClickEvent = equip;
        }

        public void SetLevel(int level, string price, string stat)
        {
            _level.text = $"{level} <size=40>LV</size>";
            _upgradeText.text = price;
            _stat.text = stat;
        }

        public void SetEquipData(bool equiped)
        {
            _equipText.SetText(equiped ? "¿Â¬¯«ÿ¡¶" : "¿Â¬¯«œ±‚");
        }
    }
}
