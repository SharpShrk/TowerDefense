using System.Collections;
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
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private GameObject _fdf;

        private EnemyCount[] _enemyCounts;
        private Coroutine _spawnWaveCoroutine;
        private WaitForSeconds _waitForSecoundsWave;
        private WaitForSeconds _waitForSecoundsEnemy;

        public Wave[] Waves => _waves;

        private void Start()
        {
            _waitForSecoundsWave = new WaitForSeconds(_timeBetweenWaves);
            _enemyPool.InitializeEnemyPool();
            StartSpawn();
        }

        private IEnumerator SpawnWaves()
        {
            foreach (var wave in _waves)
            {
                yield return _waitForSecoundsWave;
                StartCoroutine(SpawnEnemis(wave));
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
                    SpawnEnemy(wave, enemy);
                    countEnemies--;
                    yield return _waitForSecoundsEnemy;
                }
            }
        }

        private void SpawnEnemy(Wave wave, EnemyCount enemy)
        {
            if (_enemyPool.TryGetObject(enemy.EnemyCard.Id, out Enemy enemySpawn))
            {
                enemySpawn.GetComponent<EnemyHealth>().Initialize();
                enemySpawn.Init(_enemyTarget, _enemyTarget.GetPoint());
                enemySpawn.transform.position = wave.StartPoint.position;
                enemySpawn.enabled = true;
                enemySpawn.TrnasitFirstState();
                enemySpawn.gameObject.SetActive(true);
                //_enemyHandler.AddEnemy(enemySpawn);
            }
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