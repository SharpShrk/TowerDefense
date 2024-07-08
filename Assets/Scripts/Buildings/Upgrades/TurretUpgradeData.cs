using UnityEngine;

[CreateAssetMenu(fileName = "NewTurretUpgradeData", menuName = "Upgrades/Turret")]
public class TurretUpgradeData : ScriptableObject
{
    public UpgradeLevelData[] Levels;
}