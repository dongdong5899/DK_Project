using DG.Tweening;
using DKProject.Entities.Components;
using DKProject.Entities.Players;
using DKProject.SkillSystem;
using DKProject.Weapon;
using Doryu.JBSave;
using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace DKProject.Core
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        public Player Player { get; private set; }
        private PlayerSave _playerSave;
        private string _fileName = "PlayerData";
        private WeaponSO _equippedWeapon;
        private EntityStat _playerStat;
        public Vector2 PlayerMoveInput { get; private set; }

        public bool IsAutoMode { get; private set; }

        // 다음 경험치 계산을 그냥 프로퍼티에 박아버려도 될 듯
        public ulong NextRequireExp => _playerSave.level * 10;


        public void SetAutoMode(bool autoMode)
        {
            IsAutoMode = autoMode;
        }

        public void EquipWeapon(WeaponSO weapon)
        {
            _equippedWeapon = weapon;

            WeaponSaveManager.Instance.AddStat(weapon,weapon.increaseStats, _playerStat);
        }

        public void UnEquipWeapon()
        {
            WeaponSaveManager.Instance.RemoveStat(_equippedWeapon, _equippedWeapon.increaseStats, _playerStat);
            _equippedWeapon = null;

        }

        public bool CheckEquipWeapon(WeaponSO weapon)
        {
            if (_equippedWeapon != null && _equippedWeapon != weapon)
            {
                return true;
            }
            return false;
        }


        public void OnPlayerInput(Vector2 dir)
        {
            PlayerMoveInput = dir;
        }

        protected override void CreateInstance()
        {
            Player = FindFirstObjectByType<Player>();
            Load();
            _playerStat = Player.GetCompo<EntityStat>();
        }

        public void AddExp(ulong value)
        {
            _playerSave.exp += value;
            while (_playerSave.exp >= NextRequireExp)
            {
                _playerSave.exp -= NextRequireExp;
                _playerSave.level++;
                ResourceData.AddResource(ResourceType.SkillPoint, 1);
            }

            Save();
        }

        public uint GetLevel()
            => _playerSave.level;
        public ulong GetExp()
            => _playerSave.exp;
        public WeaponSO GetEquippedWeapon()
            => _equippedWeapon;

        public void Save()
        {
            _playerSave.SaveJson(_fileName);
        }

        private void Load()
        {
            _playerSave = new PlayerSave();
            if (_playerSave.LoadJson(_fileName) == false)
            {
                _playerSave.ResetData();
            }
        }
    }
}