using UnityEngine;

namespace DKProject.Entities.Enemies
{
    public class Enemy : Entity
    {
        [SerializeField] private float _attackDelay;
        private float _lastAttackTime;

        public bool IsCanAttack()
            => _lastAttackTime + _attackDelay < Time.time;
        public void CheckAttackTime()
            => _lastAttackTime = Time.time;
        public void Attack()
        {
            Debug.Log("Enemy's Attack");
        }
    }
}
