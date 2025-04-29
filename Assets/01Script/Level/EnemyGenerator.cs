using DKProject.Chapter;
using DKProject.Core.Pool;
using DKProject.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _spawnLoopDelay;
    [SerializeField] private int _loopCount;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Vector2 _spawnArea;
    [SerializeField] private float randomSize;
    [SerializeField] private int _maxEnemyCount;
    private int _currentEnemyCount;
    private bool _startSpawning = false;
    private float _lastSpawnLoopTime;
    private StageSO _stageInfo;

    private void Awake()
    {
        _lastSpawnLoopTime = -10000;
    }

    private void Update()
    {
        if (_startSpawning == false) return;

        if (_lastSpawnLoopTime + _spawnLoopDelay < Time.time)
        {
            _lastSpawnLoopTime = Time.time;
            StartCoroutine(SpawnCoroutine());
        }
    }

    public void Init(StageSO stageSO)
    {
        _startSpawning = true;
         _stageInfo = stageSO;
    }

    private IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < _loopCount; i++)
        {
            if (_currentEnemyCount >= _maxEnemyCount)
                yield break;

            Vector2 halfSpawnArea = _spawnArea / 2;

            float xOffset = Random.Range(-halfSpawnArea.x, halfSpawnArea.x);
            float yOffset = Random.Range(-halfSpawnArea.y, halfSpawnArea.y);
            Vector3 pos = transform.position + new Vector3(xOffset, yOffset);

            foreach (var enemyInfo in _stageInfo.appearingEnemy)
            {
                Vector3 randomPos = Random.insideUnitCircle * randomSize;
                Enemy enemy = gameObject.Pop(enemyInfo.enemyType, pos + randomPos, Quaternion.identity) as Enemy;
                enemy.OnDieEvent += HandleEnemyDieEvent;
                _currentEnemyCount++;

                if (_currentEnemyCount >= _maxEnemyCount)
                    yield break;
            }

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void HandleEnemyDieEvent(Enemy enemy)
    {
        enemy.OnDieEvent -= HandleEnemyDieEvent;
        _currentEnemyCount--;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, _spawnArea);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, _spawnArea + Vector2.one * (randomSize * 2));
    }
}
