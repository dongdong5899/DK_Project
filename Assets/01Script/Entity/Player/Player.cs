using DKProject.Cores;
using System;
using UnityEngine;

namespace DKProject.Entities.Players
{
    public class Player : Entity
    {
        protected override void Awake()
        {
            InputReader.JumpEvent += HandleJumpEvent;
        }

        private void HandleJumpEvent()
        {
            Debug.Log("Jump");
        }
    }
}