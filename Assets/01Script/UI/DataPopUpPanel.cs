using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject.UI
{
    public class DataPopUpPanel : MonoUI
    {
        [SerializeField] private Image _spriteRenderer;
        [SerializeField] private TextMeshProUGUI _name, _description, _level, _stat;
        [SerializeField] private Button _upgrade, _sub;

        public void SetData(Sprite sprite, string name, string description, Action upgrade, Action sub)
        {
            _spriteRenderer.sprite = sprite;
            _name.text = name;
            _description.text = description;
            _upgrade.OnClickEvent = upgrade;
            _sub.OnClickEvent = sub;
        }

        public void SetLevel(int level, string stat)
        {
            _level.text = $"{level} <size=40>LV</size>";
            _stat.text = stat;
        }
    }
}
