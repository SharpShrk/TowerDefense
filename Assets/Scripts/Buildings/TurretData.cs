using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Agava.YandexGames.YandexGamesEnvironment;

public class TurretData : BuildingData
{
    [SerializeField] private TurretUpgradeData _upgradeData;

    private float _attackRange;
    private float _attackCooldown;
    private float _damage;
    private float _rotationSpeed;

    public float AttackRange => _attackRange;
    public float AttackCooldown => _attackCooldown;
    public float Damage => _damage;
    public float RotationSpeed => _rotationSpeed;

    private void Start()
    {
        
        ApplyUpgrade(BuidlingLevel);
    }

    public void LevelUp(int level)
    {
        if (level <= MaxLevel)
        {
            Level++;
            ApplyUpgrade(level);
        }
    }

    //тут проверить и убедиться, что данные точно назначаются в соответствии с уровнем
    private void ApplyUpgrade(int level)
    {
        if (level <= _upgradeData.Levels.Length)
        {
            var upgradeLevelData = _upgradeData.Levels[level];
            _attackRange = upgradeLevelData.AttackRange;
            _attackCooldown = upgradeLevelData.AttackCooldown;
            _damage = upgradeLevelData.Damage;
            _rotationSpeed = upgradeLevelData.RotationSpeed;

            Debug.Log("Уровень повышен до " + Level);
        }
        else
        {
            Debug.Log("Произошла какая то ошибка при апгрейде");
        }
    }
}