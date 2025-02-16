using System.Collections.Generic;
using System.Linq;
using LogicGame;
using UnityEngine;

namespace EnemyLogic
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyContainer;
        [SerializeField] private WaveSpawner _waveSpawner;
        [SerializeField] private EnemyHandler _enemyHandler;
        
        private Wave[] _waves;
        private EnemyCount[] _enemyCounts;
        private List<Enemy> _enemies;

        private void Awake()
        {
            _waves = _waveSpawner.Waves;
        }

        public void InitializeEnemyPool()
        {
            _enemies = new List<Enemy>();

            foreach (var wave in _waves)
            {
                _enemyCounts = wave.EnemyCounts;

                foreach (var enemy in _enemyCounts)
                {
                    int countEnemies = enemy.Count;

                    for (int i = 0; i < countEnemies; i++)
                    {
                        Enemy spawned = Instantiate(enemy.EnemyCard.Template, _enemyContainer.transform);
                        spawned.enabled = false;
                        spawned.gameObject.SetActive(false);
                        _enemyHandler.AddEnemy(spawned);
                        _enemies.Add(spawned);
                    }
                }
            }
        }

        public bool TryGetObject(int id,out Enemy result)
        {
            result = _enemies.FirstOrDefault(enemy => enemy.gameObject.activeSelf == false && enemy.EnemyCard.Id == id);
            _enemies.Remove(result);
            return result != null;
        }
    }
}