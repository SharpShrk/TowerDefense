using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyLogic
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _health;

        private int _maxHealth;

        public event Action<int> HealthChanged;

        public event Action MaxHealthChanged;

        public event Action Died;

        public int Health => _health;

        public int MaxHealth => _maxHealth;

        public void Initialize(int health)
        {
            _health = health;
            _maxHealth = health;
            //_isDied = false;
            gameObject.GetComponent<Collider>().enabled = true;
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

            HealthChanged?.Invoke(_health);
        }

        public void OnResetHealth()
        {
            _health = _maxHealth;
            MaxHealthChanged?.Invoke();
        }
    }
}