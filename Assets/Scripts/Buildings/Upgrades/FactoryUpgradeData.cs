using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "NewFactoryUpgradeData", menuName = "Upgrades/Factory")]
    public class FactoryUpgradeData : ScriptableObject
    {
        public FactoryUpgradeLevelData[] Levels;
    }
}