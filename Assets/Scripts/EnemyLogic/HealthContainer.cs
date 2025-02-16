using System;
using Interfaces;
using UnityEngine;

namespace EnemyLogic
{
    public abstract class HealthContainer : MonoBehaviour, IDamageable
    {
        protected int _health;
        protected int _maxHealth;

        public event Action<int, int> HealthChanged;

        public event Action Died;

        public int Health => _health;

        public int MaxHealth => _maxHealth;

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

        public void SetMaxHealth(int maxHealth)
        {
            _health = maxHealth;
            _maxHealth = maxHealth;

            HealthChanged?.Invoke(_health, _maxHealth);
        }

        protected void Init(int health)
        {
            _maxHealth = health;
            _health = _maxHealth;
        }

        protected void AddHealth(int addedHealth)
        {
            if (_health + addedHealth > _maxHealth)
            {
                _health = _maxHealth;
            }
            else
            {
                _health += addedHealth;
            }

            HealthChanged?.Invoke(_health, _maxHealth);
        }
    }
}