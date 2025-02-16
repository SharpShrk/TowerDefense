using UnityEngine;

namespace Buildings.Upgrades.MainBaseUpgrade
{
    [CreateAssetMenu(fileName = "NewBaseUpgradeData", menuName = "Upgrades/MainBase")]
    public class MainBaseUpgradeData : ScriptableObject
    {
        public MainBaseUpgradeLevelData[] Levels;
    }
}