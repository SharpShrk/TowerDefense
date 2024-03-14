using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretData : BuildData
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _damage;
    [SerializeField] private float _rotationSpeed;

    public float AttackRange => _attackRange;
    public float AttackCooldown => _attackCooldown;
    public float Damage => _damage;
    public float RotationSpeed => _rotationSpeed;
}