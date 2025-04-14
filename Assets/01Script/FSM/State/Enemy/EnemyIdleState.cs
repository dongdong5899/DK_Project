using DKProject.Animators;
using DKProject.Entities;
using DKProject.Entities.Components;
using DKProject.Entities.Enemies;
using DKProject.Entities.Players;
using UnityEngine;

namespace DKProject.FSM
{
    public class EnemyIdleState : StateBase
    {
        private Enemy _enemy;
        private EntityMover _entityMover;

        public EnemyIdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _enemy = entity as Enemy;
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
                    if (_enemy.IsCanAttack())
                    {
                        _entityState.ChangeState(StateName.Attack);
                    }
                    else
                    {
                        _entityRenderer.FlipController(Mathf.Sign(dir.x));
                    }
                }
                else
                {
                    _entityState.ChangeState(StateName.Chase);
                }
            }
        }
    }
}
