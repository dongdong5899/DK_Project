using DKProject.Cores.Pool;
using DKProject.Entities.Enemies;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    private float _lastSpawnTime;

    private void Update()
    {
        if (_lastSpawnTime + _spawnDelay < Time.time)
        {
            _lastSpawnTime = Time.time;
            Vector3 pos = transform.position + (Vector3)Random.insideUnitCircle * 10f;
            Enemy enemy = gameObject.Pop(EnemyPoolingType.DefaultEnemy, pos, Quaternion.identity) as Enemy;
        }
    }
}
