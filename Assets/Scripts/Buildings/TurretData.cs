using System;
using Buildings.Upgrades;
using UnityEngine;

namespace Buildings
{
    public class TurretData : BuildingData
    {
        [SerializeField] private TurretUpgradeData _upgradeData;

        private float _attackRange;
        private float _attackCooldown;
        private float _damage;
        private float _rotationSpeed;

        public event Action OnParametersUpdated;

        public float AttackRange => _attackRange;
        public float AttackCooldown => _attackCooldown;
        public float Damage => _damage;
        public float RotationSpeed => _rotationSpeed;

        private void Awake()
        {
            ApplyUpgrade(BuidlingLevel);
        }

        protected override void ApplyUpgrade(int level)
        {
            if (level <= _upgradeData.Levels.Length)
            {
                var upgradeLevelData = _upgradeData.Levels[level - 1];
                _attackRange = upgradeLevelData.AttackRange;
                _attackCooldown = upgradeLevelData.AttackCooldown;
                _damage = upgradeLevelData.Damage;
                _rotationSpeed = upgradeLevelData.RotationSpeed;

                OnParametersUpdated?.Invoke();
            }
        }
    }
}