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
            Init(_enemy.EnemyCard.Health);
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }
}