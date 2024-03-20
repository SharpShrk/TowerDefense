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
        
        private EnemyCount[] _enemyCounts;
        private Coroutine _spawnWaveCoroutine;
        private WaitForSeconds _waitForSecoundsWave;
        private WaitForSeconds _waitForSecoundsEnemy;

        public Wave[] Waves => _waves;

        private float _countdown = 10f;
        private int _waveIndex = 0;

        private void Start()
        {
            _waitForSecoundsWave = new WaitForSeconds(_timeBetweenWaves);
            _enemyPool.InitializeEnemyPool();
            //StartSpawn();
        }

        private void Update()
        {
            if (_enemyHandler.EnemiesIsAlive > 0)
            {
                return;
            }

            if (_waveIndex == _waves.Length)
            { ;
                this.enabled = false;
            }

            if (_countdown <= 0)
            {
                SpawnWaves();
                //StartCoroutine(SpawnWaves());
                _countdown = _timeBetweenWaves;
                return;
            }

            _countdown -= Time.deltaTime;
        }

        //private IEnumerator SpawnWaves()
        //{
        //    foreach (var wave in _waves)
        //    {
        //        yield return _waitForSecoundsWave;

        //        foreach (var enemy in wave.EnemyCounts)
        //        {
        //            _enemyHandler._enemiesIsAlive += enemy.Count;
        //        }

        //        StartCoroutine(SpawnEnemis(wave));
        //    }
        //}

        private void SpawnWaves()
        {
            Wave wave = _waves[_waveIndex];
            _enemyHandler.InitEnemisIsWave(wave);
            StartCoroutine(SpawnEnemis(wave));
            _waveIndex++;
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
                enemySpawn.TransitFirstState();
                enemySpawn.gameObject.SetActive(true);
                //_enemyHandler.AddEnemy(enemySpawn);
            }
        }

        //private void StartSpawn()
        //{
        //    if (_spawnWaveCoroutine != null)
        //    {
        //        StopCoroutine(_spawnWaveCoroutine);
        //    }

        //    _spawnWaveCoroutine = StartCoroutine(SpawnWaves());
        //}
    }
}