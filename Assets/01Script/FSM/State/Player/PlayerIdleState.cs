using DKProject.Animators;
using DKProject.Core;
using DKProject.Entities;
using DKProject.Entities.Components;
using DKProject.Entities.Players;
using DKProject.StatSystem;
using UnityEngine;

namespace DKProject.FSM
{
    public class PlayerIdleState : StateBase
    {
        private Player _player;
        private EntityMover _entityMover;
        private PlayerRenderer _playerRenderer;
        private StatElement _speedStat;

        public PlayerIdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _entityMover = entity.GetCompo<EntityMover>();
            _playerRenderer = _entityRenderer as PlayerRenderer;
            _speedStat = entity.GetCompo<EntityStat>().StatDictionary[StatName.MoveSpeed];
        }

        public override void Enter()
        {
            base.Enter();
            _entityMover.StopImmediately();
        }

        public override void Update()
        {
            base.Update();

            if (PlayerManager.Instance.IsAutoMode)
            {
                _entityState.ChangeState(StateName.Chase);
            }
            else
            {
                if (_entity.IsTargetInRange(_entity.TargetDetectRange, out Collider2D collider))
                {
                    Vector2 dir = collider.transform.position - _entity.transform.position;
                    if (dir.magnitude < _entity.AttackRange)
                    {
                        if (_player.IsCanAttack())
                        {
                            _entityState.ChangeState(StateName.Attack);
                        }
                        else
                        {
                            _entityRenderer.FlipController(Mathf.Sign(dir.x));
                            _playerRenderer.SetFace(EPlayerFaceType.Default);
                        }
                    }
                    else
                    {
                        _entityState.ChangeState(StateName.Chase);
                    }
                }
                else
                {
                    _playerRenderer.SetFace(EPlayerFaceType.Surprise);
                }
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}