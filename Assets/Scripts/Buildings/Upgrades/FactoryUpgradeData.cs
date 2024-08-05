using UnityEngine;

[CreateAssetMenu(fileName = "NewFactoryUpgradeData", menuName = "Upgrades/Factory")]
public class FactoryUpgradeData : ScriptableObject
{
    public FactoryUpgradeLevelData[] Levels;
}