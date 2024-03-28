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
        [SerializeField] private PointerHandler _pointerHandler;
        
        private EnemyCount[] _enemyCounts;
        private Coroutine _spawnWaveCoroutine;
        private WaitForSeconds _waitForSecoundsWave;
        private WaitForSeconds _waitForSecoundsEnemy;
        private float _countdown = 10f;
        private int _waveIndex;

        public Wave[] Waves => _waves;

        private void OnEnable()
        {
            _enemyHandler.AliveEnemiesKilled += OnSpawnWaves;
        }

        private void OnDisable()
        {
            _enemyHandler.AliveEnemiesKilled -= OnSpawnWaves;
        }

        private void Start()
        {
            _waitForSecoundsWave = new WaitForSeconds(_countdown);
            _enemyPool.InitializeEnemyPool();
        }

        private void OnSpawnWaves()
        {
            if (_enemyHandler.EnemiesIsAlive > 0)
            {
                return;
            }

            if (_waveIndex == _waves.Length-1)
            {
                enabled = false;
            }

            StartSpawn();
        }

        private IEnumerator SpawnWaves()
        {
            yield return _waitForSecoundsWave;
            SpawnWave();
            _waitForSecoundsWave = new WaitForSeconds(_timeBetweenWaves);

        }

        private void SpawnWave()
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
                _pointerHandler.AddToList(enemySpawn.GetComponent<EnemyPointer>());
                enemySpawn.GetComponent<EnemyHealth>().Initialize();
                enemySpawn.GetComponent<EnemyPointer>().Init(_pointerHandler);
                enemySpawn.Init(_enemyTarget, _enemyTarget.GetPoint());
                enemySpawn.transform.position = wave.StartPoint.position;
                enemySpawn.enabled = true;
                enemySpawn.TransitFirstState();
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