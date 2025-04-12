using DKProject.Animators;
using DKProject.Entities;
using DKProject.Entities.Components;
using DKProject.Entities.Players;
using UnityEngine;

namespace DKProject.FSM
{
    public class PlayerMoveState : StateBase
    {
        private Player _player;
        private EntityMover _entityMover;

        public PlayerMoveState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _entityMover = entity.GetCompo<EntityMover>();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            Vector2 dir = (_player.TargetTrm.position - _player.transform.position).normalized;
            _entityMover.SetMovement(dir);

            if (_player.IsTargetInRange(15f) == false || _player.IsTargetInRange(1.5f))
            {
                _entityState.ChangeState(StateName.Idle);
            }

            _entityRenderer.FlipController(Mathf.Sign(dir.x));
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
