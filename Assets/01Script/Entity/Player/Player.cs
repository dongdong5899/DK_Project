using DKProject.Cores;
using System;
using UnityEngine;

namespace DKProject.Entities.Players
{
    public class Player : Entity
    {
        [field: SerializeField] public Transform TargetTrm { get; private set; }

        public bool IsTargetInRange(float range)
        {
            return Vector2.Distance(TargetTrm.transform.position, transform.position) < range;
        }
    }
}