using System;
using System.Collections;
using Abilities;
using EnemyLogic;
using UnityEngine;
using Wallets;

namespace GameLogic
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyHandler _enemyHandler;
        [SerializeField] private float _timeBetweenWaves = 5f;
        [SerializeField] private float _startDelay = 30f;
        [SerializeField] private Wave[] _waves;
        [SerializeField] private Transform _container;
        [SerializeField] private EnemyTarget _enemyTarget;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private PointerHandler _pointerHandler;
        [SerializeField] private Score _score;
        [SerializeField] private DestroyEnemiesAbility _destroyEnemiesAbility;
        [SerializeField] private FreezeEnemiesAbility _freezeEnemiesAbility;
        [SerializeField] private StrikeEnemiesAbility _strikeEnemiesAbility;

        private EnemyCount[] _enemyCounts;
        private Coroutine _spawnWaveCoroutine;
        private WaitForSeconds _waitForSecoundsWave;
        private WaitForSeconds _waitForSecoundsEnemy;
        private int _waveIndex;

        public event Action<int, int> WaveChanger;

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
            _waitForSecoundsWave = new WaitForSeconds(_startDelay);
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
            WaveChanger?.Invoke(_waveIndex, _waves.Length);
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
                enemySpawn.Init(_enemyTarget,
                    _enemyTarget.GetPoint(),
                    _score,
                    _destroyEnemiesAbility,
                    _freezeEnemiesAbility,
                    _strikeEnemiesAbility);
                enemySpawn.transform.position = wave.StartPoint.position;
                enemySpawn.enabled = true;
                enemySpawn.TransitFirstState();
                enemySpawn.gameObject.SetActive(true);
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