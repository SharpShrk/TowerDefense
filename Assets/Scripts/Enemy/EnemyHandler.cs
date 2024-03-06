using System;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyLogic
{
    public class EnemyHandler : MonoBehaviour
    {
        [SerializeField] private EnemyTarget _enemyTarget;

        private List<Enemy> _enemies;

        public event Action AllEnemiesKilled;

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

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
            enemy.Died += OnEnemyDeath;
        }

        public void OnEnemyDeath(Enemy enemy)
        {
            _enemies.Remove(enemy);
            enemy.Died -= OnEnemyDeath;

            if (_enemies.Count <= 0)
            {
                AllEnemiesKilled?.Invoke();
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