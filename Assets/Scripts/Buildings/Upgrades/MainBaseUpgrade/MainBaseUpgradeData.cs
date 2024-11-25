using UnityEngine;

namespace MainBaseUpgrade
{
    [CreateAssetMenu(fileName = "NewBaseUpgradeData", menuName = "Upgrades/MainBase")]
    public class MainBaseUpgradeData : ScriptableObject
    {
        public MainBaseUpgradeLevelData[] Levels;
    }
}