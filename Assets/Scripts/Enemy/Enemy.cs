using UnityEngine;

namespace EnemyLogic
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _startSpeed = 10f;
        [SerializeField] private float _startHealth = 100f;
        [SerializeField] private int _worth = 2;
        [SerializeField] private GameObject _deathEffect;

        private EnemyHandler _enemyHandler;
        private float _curretSpeed;
        private float _health;

        public float CurrentSpeed => _curretSpeed;

        public float Health => _health;

        public int Worth => _worth;

        private void Start()
        {
            _curretSpeed = _startSpeed;
            _health = _startHealth;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
        }

        public void Init(EnemyHandler enemyHandler)
        {
            _enemyHandler = enemyHandler;
        }

        public void Slow(float value)
        {
            _curretSpeed = _startSpeed * (1f - value);
        }

        public void ResetSpeed()
        {
            _curretSpeed = _startSpeed;
        }

        public void Die()
        {
            _enemyHandler.EnemyDeath(this);
            GameObject deathEffect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
            Destroy(deathEffect, 2f);
            Destroy(gameObject);
        }
    }
}