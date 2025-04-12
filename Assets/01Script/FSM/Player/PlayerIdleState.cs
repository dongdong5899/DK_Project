using DKProject.Animators;
using DKProject.Entities;
using UnityEngine;

namespace DKProject.FSM
{
    public class PlayerIdleState : StateBase
    {
        public PlayerIdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}