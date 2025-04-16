using DKProject.Entities.Components;
using DKProject.Entities.Players;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DKProject.Core
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        public Player Player { get; private set; }

        public Vector2 PlayerMoveInput { get; private set; }

        public bool IsAutoMode { get; private set; }

        public void SetAutoMode(bool autoMode)
        {
            IsAutoMode = autoMode;
        }

        public void OnPlayerInput(Vector2 dir)
        {
            PlayerMoveInput = dir;
        }

        protected override void CreateInstance()
        {
            Player = FindFirstObjectByType<Player>();
        }
    }
}