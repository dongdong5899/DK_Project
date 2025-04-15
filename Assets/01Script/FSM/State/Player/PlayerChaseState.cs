using DKProject.Animators;
using DKProject.Entities;
using DKProject.Entities.Components;
using DKProject.Entities.Players;
using DKProject.StatSystem;
using UnityEngine;

namespace DKProject.FSM
{
    public class PlayerChaseState : StateBase
    {
        private Player _player;
        private EntityMover _entityMover;
        private PlayerRenderer _playerRenderer;
        private StatElement _speedStat;

        public PlayerChaseState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _entityMover = entity.GetCompo<EntityMover>();
            _playerRenderer = _entityRenderer as PlayerRenderer;
            _speedStat = entity.GetCompo<EntityStat>().StatDictionary[StatName.MoveSpeed];
        }

        public override void Enter()
        {
            base.Enter();
            _playerRenderer.SetFace(EPlayerFaceType.Default);
        }

        public override void Update()
        {
            base.Update();


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
                        _entityState.ChangeState(StateName.Idle);
                    }
                }
                else
                {
                    _entityMover.SetMovement(dir.normalized * _speedStat.Value);
                    _entityRenderer.FlipController(Mathf.Sign(dir.x));
                }
            }
            else
            {
                _entityState.ChangeState(StateName.Idle);
            }

        }
    }
}
