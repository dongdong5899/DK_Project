using DKProject.Animators;
using DKProject.Entities;
using UnityEngine;

namespace DKProject.FSM
{
    public class EnemyPatrolState : StateBase
    {
        public EnemyPatrolState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
        }
    }
}
