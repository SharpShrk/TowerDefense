using UnityEngine;

public class ResourcesFactoryData : BuildingData
{
    [SerializeField] private FactoryUpgradeData _upgradeData;

    private float _cooldown;

    public float Cooldown => _cooldown;

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
        }
    }
}