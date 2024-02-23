using System.Collections;
using System.Collections.Generic;
using EnemyLogic;
using UnityEngine;

namespace GameLogic
{
    public class WaveSpawner : MonoBehaviour
    {
        public int EnemiesAlive = 0;

        [SerializeField] private EnemyHandler _enemyHandler;
        [SerializeField] private float _timeBetweenWaves = 5f;
        [SerializeField] private Wave[] _waves;
        [SerializeField] private Transform _container;

        private EnemyCount[] _enemyCounts;
        private float _countdown = 2.0f;
        private int _waveIndex;
        private List<Enemy> _enemies = new List<Enemy>();

        public List<Enemy> Enemies => _enemies;

        private void Update()
        {
            //if (EnemiesAlive > 0)
            //{
            //    return;
            //}

            if (_waveIndex == _waves.Length)
            {
                this.enabled = false;
            }

            if (_countdown <= 0)
            {
                StartCoroutine(SpawnWaves());
                _countdown = _timeBetweenWaves;
                return;
            }

            _countdown -= Time.deltaTime;
        }

        private IEnumerator SpawnWaves()
        {
            Wave wave = _waves[_waveIndex];
            
            for (int i = 0; i < wave.EnemyCounts.Length; i++)
            {
                StartCoroutine(SpawnEnemis(wave));
                yield return new WaitForSeconds(1f / wave.Rate);
            }

            _waveIndex++;
        }

        private IEnumerator SpawnEnemis(Wave wave)
        {
            _enemyCounts = wave.EnemyCounts;

            foreach (var enemy in _enemyCounts)
            {
                int countEnemies = enemy.Count;
                EnemiesAlive = countEnemies;

                while (countEnemies > 0)
                {
                    SpawnEnemy(wave, enemy);
                    yield return new WaitForSeconds(1f / wave.Rate);
                    countEnemies--;
                }
            }
        }

        private void SpawnEnemy(Wave wave, EnemyCount enemy)
        {
            Enemy EnemySpawn = null;
            EnemySpawn = Instantiate(enemy.Enemy, wave.WayPoints[0].position, Quaternion.identity, _container);
            EnemySpawn.GetComponent<EnemyMove>().Init(wave.WayPoints);
            EnemySpawn.Init(_enemyHandler);
            _enemyHandler.AddEnemy(EnemySpawn);
        }
    }
}