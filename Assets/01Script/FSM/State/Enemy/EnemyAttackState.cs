using DKProject.Animators;
using DKProject.Entities;
using DKProject.Entities.Components;
using DKProject.Entities.Enemies;
using DKProject.Entities.Players;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace DKProject.FSM
{
    public class EnemyAttackState : StateBase
    {
        private Enemy _enemy;
        private EntityMover _entityMover;

        public EnemyAttackState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _enemy = entity as Enemy;
            _entityMover = entity.GetCompo<EntityMover>();
        }

        public override void Enter()
        {
            base.Enter();
            _entityMover.StopImmediately();
        }

        protected override void HandleAnimationEvent(EAnimationEventType type)
        {
            base.HandleAnimationEvent(type);
            if (type == EAnimationEventType.Trigger)
            {
                _enemy.Attack();
            }
            else if (type == EAnimationEventType.End)
            {
                _entityState.ChangeState(StateName.Idle);
                _enemy.CheckAttackTime();
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
