using UnityEngine;

namespace EnemyLogic
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyHealth : HealthContainer
    {
        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        public void Initialize()
        {
            _maxHealth = _enemy.EnemyCard.Health;
            _health = _maxHealth;
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }
}