using UnityEngine;

public class UpgradePresenter : MonoBehaviour
{
    [SerializeField] private UpgradeView _view;
    [SerializeField] private EnergyWallet _wallet;

    private int _buildingCostUpgrade;

    public void OnBuildingSelected(GameObject building)
    {
        var upgradeable = building.GetComponent<IUpgradeable>();
        _view.ShowUpgradeOptions(upgradeable);
    }

    public void TryUpgradeBuilding(IUpgradeable building)
    {
        BuildingData buildingData = building.gameObject.GetComponent<BuildingData>();

        if (_wallet.SpendEnergy(buildingData.BuildinCostUpgrade))
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