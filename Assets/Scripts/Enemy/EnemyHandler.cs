using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyLogic
{
    public class EnemyHandler : MonoBehaviour
    {
        private List<Enemy> _enemies;

        public event Action AllEnemiesKilled;

        private void Awake()
        {
            _enemies = new List<Enemy>();
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void EnemyDeath(Enemy enemy)
        {
            _enemies.Remove(enemy);
            
            if (_enemies.Count <= 0)
            {
                AllEnemiesKilled?.Invoke();
            }
        }

        private void OnDestroyEnemies()
        {
            foreach (var enemy in _enemies)
            {
                Destroy(enemy.gameObject);
            }

            _enemies.Clear();
        }
    }
}