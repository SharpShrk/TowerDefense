using Buildings;
using Interfaces;
using UnityEngine;
using Wallets;

namespace Upgrades
{
    public class UpgradePresenter : MonoBehaviour
    {
        [SerializeField] private UpgradeView _view;
        [SerializeField] private EnergyWallet _wallet;

        public void OnBuildingSelected(GameObject building)
        {
            var upgradeable = building.GetComponent<IUpgradeable>();

            _view.ShowUpgradeOptions(upgradeable);
        }

        public void TryUpgradeBuilding(IUpgradeable building)
        {
            BuildingData buildingData = building.gameObject.GetComponent<BuildingData>();

            if (_wallet.SpendResource(buildingData.BuildinCostUpgrade))
            {
                UpgradeBuidlding(building);
            }
        }

        public void UpgradeBuidlding(IUpgradeable building)
        {
            building.Upgrade();
            _view.HideUpgradeOptions();
        }
    }
}