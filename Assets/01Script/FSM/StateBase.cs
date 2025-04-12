using DKProject.Animators;
using DKProject.Entities;
using DKProject.Entities.Components;
using System;

namespace DKProject.FSM
{
    [Flags]
    public enum EAnimationEventType
    {
        Start = 1,
        End = 2,
        Trigger = 4,
    }

    public abstract class StateBase
    {
        protected Entity _entity;
        
        protected AnimParamSO _animParam;
        protected EAnimationEventType _isTriggerCall;

        protected EntityRenderer _renderer;

        public StateBase(Entity entity, AnimParamSO animParam)
        {
            _entity = entity;
            _animParam = animParam;
            _renderer = _entity.GetCompo<EntityRenderer>();
        }

        public virtual void Enter()
        {
            _renderer.SetParam(_animParam, true);
            _renderer.OnAnimationEvent += HandleAnimationEvent;
            _isTriggerCall = 0;
        }

        protected virtual void HandleAnimationEvent(EAnimationEventType type)
        {
            _isTriggerCall |= type;
        }

        public virtual void Update() { }

        public virtual void Exit()
        {
            _renderer.SetParam(_animParam, false);
        }
    }
}
