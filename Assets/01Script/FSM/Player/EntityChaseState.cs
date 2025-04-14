using DKProject.Animators;
using DKProject.Entities;
using DKProject.Entities.Components;
using DKProject.Entities.Players;
using UnityEngine;

namespace DKProject.FSM
{
    public class EntityChaseState : StateBase
    {
        private EntityMover _entityMover;
        private float _speed = 5f;

        public EntityChaseState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _entityMover = entity.GetCompo<EntityMover>();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();


            if (_entity.IsTargetInRange(15f, out Collider2D collider))
            {
                Vector2 dir = collider.transform.position - _entity.transform.position;
                if (dir.magnitude < 1.5f)
                {
                    _entityState.ChangeState(StateName.Idle);
                }
                else
                {
                    _entityMover.SetMovement(dir.normalized * _speed);
                    _entityRenderer.FlipController(Mathf.Sign(dir.x));
                }
            }
            else
            {
                _entityState.ChangeState(StateName.Idle);
            }

        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
