using UnityEngine;

namespace Buildings.Upgrades
{
    [CreateAssetMenu(fileName = "NewTurretUpgradeData", menuName = "Upgrades/Turret")]
    public class TurretUpgradeData : ScriptableObject
    {
        public TurretUpgradeLevelData[] Levels;
    }
}