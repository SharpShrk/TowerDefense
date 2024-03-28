using System;
using System.Collections.Generic;
using GameLogic;
using UnityEngine;

namespace EnemyLogic
{
    public class EnemyHandler : MonoBehaviour
    {
        [SerializeField] private EnemyTarget _enemyTarget;

        private List<Enemy> _enemies;
        private int _enemiesIsAlive;

        public event Action AllEnemiesKilled;

        public event Action AliveEnemiesKilled;

        public int EnemiesIsAlive => _enemiesIsAlive;

        private void Awake()
        {
            _enemies = new List<Enemy>();
        }

        private void OnEnable()
        {
            _enemyTarget.Died += OnDestroyEnemies;
        }

        private void OnDisable()
        {
            _enemyTarget.Died -= OnDestroyEnemies;
        }

        private void Start()
        {
            AliveEnemiesKilled?.Invoke();
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
            enemy.Died += OnEnemyDeath;
        }

        public void OnEnemyDeath(Enemy enemy)
        {
            _enemies.Remove(enemy);
            _enemiesIsAlive--;
            enemy.Died -= OnEnemyDeath;

            if (_enemiesIsAlive <= 0)
            {
                AliveEnemiesKilled?.Invoke();
            }

            if (_enemies.Count <= 0)
            {
                AllEnemiesKilled?.Invoke();
            }
        }

        public void InitEnemisIsWave(Wave wave)
        {
            foreach (var enemy in wave.EnemyCounts)
            {
                _enemiesIsAlive += enemy.Count;
            }
        }

        private void OnDestroyEnemies()
        {
            foreach (var enemy in _enemies)
            {
                enemy.gameObject.SetActive(false);
            }

            _enemies.Clear();
        }
    }
}