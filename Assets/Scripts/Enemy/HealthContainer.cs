using System;
using EnemyLogic;
using UnityEngine;

public abstract class HealthContainer : MonoBehaviour , IDamageable
{
    protected int _health;

    protected int _maxHealth;

    public event Action<int> HealthChanged;

    public event Action MaxHealthChanged;

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

        HealthChanged?.Invoke(_health);
    }
}
