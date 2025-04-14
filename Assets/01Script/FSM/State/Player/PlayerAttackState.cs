using DKProject.Animators;
using DKProject.Entities;
using DKProject.Entities.Components;
using DKProject.Entities.Players;
using DKProject.StatSystem;
using UnityEngine;

namespace DKProject.FSM
{
    public class PlayerAttackState : StateBase
    {
        private Player _player;
        private EntityMover _entityMover;
        private PlayerRenderer _playerRenderer;
        private StatElement _attackSpeedStat;

        public PlayerAttackState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _entityMover = entity.GetCompo<EntityMover>();
            _playerRenderer = _entityRenderer as PlayerRenderer;
            _attackSpeedStat = entity.GetCompo<EntityStat>().StatDictionary[StatName.AttackSpeed];
        }

        public override void Enter()
        {
            base.Enter();
            _entityMover.StopImmediately();
            _playerRenderer.SetFace(EPlayerFaceType.Angry);
            _player.CheckAttackTime();
            _entityRenderer.SetAnimationSpeed(Mathf.Clamp(_attackSpeedStat.Value / (37f / 60f), 0f, 1f));
        }

        protected override void HandleAnimationEvent(EAnimationEventType type)
        {
            base.HandleAnimationEvent(type);
            if (type == EAnimationEventType.Trigger)
            {
                _player.Attack();
            }
            else if (type == EAnimationEventType.End)
            {
                _entityState.ChangeState(StateName.Idle);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _entityRenderer.SetAnimationSpeed(1);
        }
    }
}
