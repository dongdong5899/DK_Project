using DKProject.Animators;
using DKProject.Entities;
using DKProject.Entities.Components;
using UnityEngine;

namespace DKProject.FSM
{
    public class EntityIdleState : StateBase
    {
        private EntityMover _entityMover;

        public EntityIdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _entityMover = entity.GetCompo<EntityMover>();
        }

        public override void Enter()
        {
            base.Enter();
            _entityMover.StopImmediately();
        }

        public override void Update()
        {
            base.Update();

            if (_entity.IsTargetInRange(15f, out Collider2D collider))
            {
                Vector2 dir = collider.transform.position - _entity.transform.position;
                if (dir.magnitude < 1.5f)
                {
                    _entityRenderer.FlipController(Mathf.Sign(dir.x));
                }
                else
                {
                    _entityState.ChangeState(StateName.Chase);
                }
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}