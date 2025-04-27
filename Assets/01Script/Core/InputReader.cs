using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DKProject.Core
{
    public class InputReader : Controls.IPlayerActions
    {

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
        }
    }
}
