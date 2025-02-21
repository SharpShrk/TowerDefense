using Interfaces;
using UnityEngine;
using Wallets;

namespace Buildings.Upgrades
{
    public class UpgradePresenter : MonoBehaviour
    {
        [SerializeField] private UpgradeView _view;
        [SerializeField] private ResourceWallet _energyWallet;

        public void OnBuildingSelected(GameObject building)
        {
            var upgradeable = building.GetComponent<IUpgradeable>();

            _view.ShowUpgradeOptions(upgradeable);
        }

        public void TryUpgradeBuilding(IUpgradeable building)
        {
            BuildingData buildingData = building.gameObject.GetComponent<BuildingData>();

            if (_energyWallet.SpendResource(buildingData.BuildinCostUpgrade))
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