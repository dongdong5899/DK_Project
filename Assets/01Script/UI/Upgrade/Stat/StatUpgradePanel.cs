using DKProject.Core;
using DKProject.Entities.Components;
using DKProject.StatSystem;
using DKProject.UI;
using NUnit.Framework;
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
        [SerializeField] private float _defaultPrice, _priceIncreaseValue;
        [SerializeField] private float _defaultUpgrade, _upgradeIncreaseValue;
        [SerializeField] private string _mexLevel;
        private BigInteger _mexLevelValue;

        private StatDictionary _playerStatDictionary;

        private BigInteger _levelValue;

        private void Start()
        {
            _mexLevelValue = string.IsNullOrEmpty(_mexLevel) ? -1 : BigInteger.Parse(_mexLevel);
            _levelValue = 1;
            _name.text = _statSO.displayName;
            _playerStatDictionary = PlayerManager.Instance.Player.GetCompo<EntityStat>().StatDictionary;
            UpdateData();

            _button.OnClickEvent += HandleClickEvent;
        }

        private BigInteger GetPrice()
        {
            return ((ulong)(10000 * _defaultPrice) + (_levelValue - 1) * (ulong)(10000 * _priceIncreaseValue)) / 10000;
        }
        private float GetUpgradeFloatValue()
        {
            return _defaultUpgrade + ((ulong)_levelValue - 1) * _upgradeIncreaseValue;
        }
        private BigInteger GetUpgradeBigIntegerValue()
        {
            return ((ulong)(10000 * _defaultUpgrade) + (_levelValue - 1) * (ulong)(10000 * _upgradeIncreaseValue)) / 10000;
        }

        private void UpdateData()
        {
            _level.text = $"{_levelValue}LV -> <color=yellow>{_levelValue + 1}</color>LV";
            _price.text = $"{GetPrice()}G";
            _value.text = _statSO.isBigInteger ?
                _playerStatDictionary[_statSO].BigIntValue.ParseNumber() :
                _playerStatDictionary[_statSO].Value.ToString();
        }

        private void HandleClickEvent()
        {
            if (_mexLevelValue != -1 && _levelValue >= _mexLevelValue) return;

            if (ResourceData.TryRemoveResource(ResourceType.Gold, GetPrice()))
            {
                _levelValue++;
                if (_statSO.isBigInteger)
                    _playerStatDictionary[_statSO].AddModify($"{_statSO.statName}.Upgrade", GetUpgradeBigIntegerValue(), EModifyMode.Add, EModifyLayer.StatUp);
                else
                    _playerStatDictionary[_statSO].AddModify($"{_statSO.statName}.Upgrade", GetUpgradeFloatValue(), EModifyMode.Add, EModifyLayer.StatUp);
                UpdateData();
            }
        }
    }
}
