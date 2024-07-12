using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesFactoryData : BuildingData
{
    [SerializeField] private FactoryUpgradeData _upgradeData;

    private float _cooldown;
    private float _productionValue;

    public float Cooldown => _cooldown;
    public float ProductionValue => _productionValue;

    private void Start()
    {
        ApplyUpgrade(BuidlingLevel);
    }

    protected override void ApplyUpgrade(int level)
    {
        if (level <= _upgradeData.Levels.Length)
        {
            var upgradeLevelData = _upgradeData.Levels[level - 1];
            _cooldown = upgradeLevelData.Cooldown;
            _productionValue = upgradeLevelData.ProductionValue;

            Debug.Log("Уровень повышен до " + Level);
        }
        else
        {
            Debug.Log("Произошла какая то ошибка при апгрейде");
        }
    }
}
