using DKProject.Animators;
using DKProject.Cores;
using DKProject.Entities;
using DKProject.Entities.Components;
using DKProject.Entities.Enemies;
using DKProject.Entities.Players;
using DKProject.StatSystem;
using UnityEngine;

namespace DKProject.FSM
{
    public class PlayerAttackState : StateBase
    {
        private readonly static int _AttackSpeedHash = Animator.StringToHash("AttackSpeed");

        private Player _player;
        private EntityMover _entityMover;
        private EntityStat _entityStat;
        private PlayerRenderer _playerRenderer;
        private StatElement _statElement;

        private Enemy _targetEnemy;

        public PlayerAttackState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _entityMover = entity.GetCompo<EntityMover>();
            _entityStat = entity.GetCompo<EntityStat>();
            _statElement = _entityStat.StatDictionary[StatName.AttackSpeed];
            _playerRenderer = _entityRenderer as PlayerRenderer;
        }

        public override void Enter()
        {
            base.Enter();
            _entityMover.StopImmediately();
            _playerRenderer.SetFace(EPlayerFaceType.Angry);
            _playerRenderer.PlayAnimation("Player_Attack");
            float attackSpeed = _statElement.Value * 37f / 60f;
            _playerRenderer.SetParam(_AttackSpeedHash, Mathf.Clamp(attackSpeed, 1f, 10000000f));
            _player.CheckAttackTime();

            if (_entity.IsTargetInRange(1.5f, out Collider2D collider))
            {
                _targetEnemy = collider.GetComponent<Enemy>();
            }
        }

        public override void Update()
        {
            base.Update();

            if (_targetEnemy != null)
            {
                Vector3 dir = _targetEnemy.transform.position - _player.transform.position;
                _entityRenderer.FlipController(Mathf.Sign(dir.x));
            }

            if (HasTriggerCall(EAnimationEventType.Trigger))
            {
                RemoveTriggerCall(EAnimationEventType.Trigger);
                _player.Attack(_targetEnemy);
            }
            if (HasTriggerCall(EAnimationEventType.End))
            {
                _entityState.ChangeState(StateName.Idle);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _playerRenderer.SetParam(_AttackSpeedHash, 1f);
        }
    }
}
