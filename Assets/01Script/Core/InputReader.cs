using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DKProject.Cores
{
    public class InputReader : Controls.IPlayerActions
    {
        public static event Action JumpEvent;
        public static event Action DashEvent;
        public static event Action AttackEvent;

        public static Vector2 InputDirection { get; private set; }

        private static Controls _Controls;

        private static InputReader _Instance;

        static InputReader()
        {
            _Instance = new InputReader();
            _Controls = new Controls();
            _Controls.Player.SetCallbacks(_Instance);
            _Controls.Player.Enable();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                JumpEvent?.Invoke();
        }
    }
}
