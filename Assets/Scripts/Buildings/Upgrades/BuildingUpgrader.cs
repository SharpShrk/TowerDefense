using Interfaces;
using UnityEngine;

namespace Buildings.Upgrades
{
    [RequireComponent(typeof(BuildingData))]
    public class BuildingUpgrader : MonoBehaviour, IUpgradeable
    {
        private BuildingData _data;

        private void Start()
        {
            _data = GetComponent<BuildingData>();
        }

        public void Upgrade()
        {
            if (_data is TurretData turretData)
            {
                turretData.LevelUp(turretData.BuidlingLevel + 1);
            }
            else if (_data is ResourcesFactoryData factoryData)
            {
                factoryData.LevelUp(factoryData.BuidlingLevel + 1);
            }
        }
    }
}