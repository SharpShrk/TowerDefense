using System;
using UnityEngine;

namespace EnemyLogic
{
    public abstract class HealthContainer : MonoBehaviour, IDamageable
    {
        private int _health;
        private int _maxHealth;

        public event Action<int, int> HealthChanged;

        public event Action MaxHealthChanged;

        public event Action Died;

        public int Health => _health;

        public int MaxHealth => _maxHealth;

        protected void Init(int health)
        {
            _maxHealth = health;
            _health = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                return;
            }

            _health -= damage;

            if (_health <= 0)
            {
                _health = 0;
                Died?.Invoke();
            }

            HealthChanged?.Invoke(_health, _maxHealth);
        }
    }
}