using DKProject.Animators;
using DKProject.FSM;
using System;
using UnityEngine;

namespace DKProject.Entities.Components
{
    public class EntityRenderer : MonoBehaviour, IEntityComponent
    {
        public float FacingDirection { get; private set; } = 1;

        private Entity _entity;
        private Animator _animator;
        public void Initialize(Entity entity)
        {
            _entity = entity;
            _animator = GetComponent<Animator>();
        }

        public event Action<EAnimationEventType> OnAnimationEvent;

        public void SetParam(AnimParamSO param, bool value) => _animator.SetBool(param.hashValue, value);
        public void SetParam(AnimParamSO param, float value) => _animator.SetFloat(param.hashValue, value);
        public void SetParam(AnimParamSO param, int value) => _animator.SetInteger(param.hashValue, value);
        public void SetParam(AnimParamSO param) => _animator.SetTrigger(param.hashValue);

        #region FlipControl

        public void Flip()
        {
            FacingDirection *= -1;
            _entity.transform.Rotate(0, 180f, 0);
        }

        public void FlipController(float xMove)
        {
            if (Mathf.Abs(FacingDirection + xMove) < 0.5f)
                Flip();
        }

        #endregion

        private void AnimationEvent(EAnimationEventType eAnimationEventType)
        {
            OnAnimationEvent?.Invoke(eAnimationEventType);
        }
    }
}
