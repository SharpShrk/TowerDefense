using System.Collections;
using System.Collections.Generic;
using EnemyLogic;
using UnityEngine;

namespace GameLogic
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyHandler _enemyHandler;
        [SerializeField] private float _timeBetweenWaves = 5f;
        [SerializeField] private Wave[] _waves;
        [SerializeField] private Transform _container;
        [SerializeField] private EnemyTarget _enemyTarget;

        private EnemyCount[] _enemyCounts;
        private Coroutine _spawnWaveCoroutine;
        private WaitForSeconds _waitForSecoundsWave;
        private WaitForSeconds _waitForSecoundsEnemy;

        private void Start()
        {
            _waitForSecoundsWave = new WaitForSeconds(_timeBetweenWaves);
            StartSpawn();
        }

        private IEnumerator SpawnWaves()
        {
            foreach (var wave in _waves)
            {
                StartCoroutine(SpawnEnemis(wave));
                yield return _waitForSecoundsWave;
            }
        }

        private IEnumerator SpawnEnemis(Wave wave)
        {
            _enemyCounts = wave.EnemyCounts;
            
            foreach (var enemy in _enemyCounts)
            {
                int countEnemies = enemy.Count;
                _waitForSecoundsEnemy = new WaitForSeconds(enemy.Delay);

                while (countEnemies > 0)
                {
                    yield return _waitForSecoundsEnemy;
                    SpawnEnemy(wave, enemy);
                    countEnemies--;
                }
            }
        }

        private void SpawnEnemy(Wave wave, EnemyCount enemy)
        {
            Enemy enemySpawn = null;
            enemySpawn = Instantiate(enemy.Enemy, wave.StartPoint.position, Quaternion.identity, _container);
            enemySpawn.Init(_enemyTarget, _enemyTarget.GetPoint());
            //EnemySpawn.GetComponent<EnemyMove>().Init(wave.WayPoints);
            // EnemySpawn.Init(_enemyHandler);
            _enemyHandler.AddEnemy(enemySpawn);
        }

        private void StartSpawn()
        {
            if (_spawnWaveCoroutine != null)
            {
                StopCoroutine(_spawnWaveCoroutine);
            }

            _spawnWaveCoroutine = StartCoroutine(SpawnWaves());
        }
    }
}