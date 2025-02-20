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
            switch (_data)
            {
                case TurretData turretData:
                    turretData.LevelUp(turretData.BuidlingLevel + 1);
                    break;
                case ResourcesFactoryData factoryData:
                    factoryData.LevelUp(factoryData.BuidlingLevel + 1);
                    break;
            }
        }
    }
}