using DKProject.Core;
using DKProject.Entities.Components;
using DKProject.StatSystem;
using DKProject.UI;
using System;
using System.Numerics;
using TMPro;
using UnityEngine;

namespace DKProject
{
    public class StatUpgradePanel : MonoBehaviour
    {
        [SerializeField] private StatElementSO _statSO;
        [SerializeField] private TextMeshProUGUI _name, _level, _value, _price;
        [SerializeField] private Button _button;
        [SerializeField] private int _defaultPrice, _PriceIncreaseValue;
        [SerializeField] private int _defaultUpgrade, _upgradeIncreaseValue;

        private StatDictionary _playerStatDictionary;

        private int _levelValue;

        private void Start()
        {
            _levelValue = 1;
            _name.text = _statSO.displayName;
            _playerStatDictionary = PlayerManager.Instance.Player.GetCompo<EntityStat>().StatDictionary;
            UpdateData();

            _button.OnClickEvent += HandleClickEvent;
        }

        private int GetPrice()
        {
            return Mathf.CeilToInt(_defaultPrice + (_levelValue - 1) * _PriceIncreaseValue);
        }
        private int GetUpgradeValue()
        {
            return Mathf.CeilToInt(_defaultUpgrade + (_levelValue - 1) * _upgradeIncreaseValue);
        }

        private void UpdateData()
        {
            _level.text = $"{_levelValue} -> {_levelValue + 1}";
            _price.text = $"{GetPrice()}";
            _value.text = _statSO.isBigInteger ?
                _playerStatDictionary[_statSO].BigIntValue.ParseNumber() :
                ((ulong)_playerStatDictionary[_statSO].IntValue).ParseNumber();
        }

        private void HandleClickEvent()
        {
            _levelValue++;
            if (_statSO.isBigInteger)
                _playerStatDictionary[_statSO].AddModify($"{_statSO.statName}.Upgrade", (BigInteger)GetUpgradeValue(), EModifyMode.Add, EModifyLayer.StatUp, false);
            else
                _playerStatDictionary[_statSO].AddModify($"{_statSO.statName}.Upgrade", (float)GetUpgradeValue(), EModifyMode.Add, EModifyLayer.StatUp, false);
            UpdateData();
        }
    }
}
