using Agava.YandexGames;
using UnityEngine;

public class UpgradePresenter: MonoBehaviour
{
    [SerializeField] private UpgradeView _view;
    [SerializeField] private MetalWallet _wallet;

    private int _buildingCostUpgrade;

    public void OnBuildingSelected(GameObject building)
    {
        var upgradeable = building.GetComponent<IUpgradeable>();

        _view.ShowUpgradeOptions(upgradeable);
    }

    public void TryUpgradeBuilding(IUpgradeable building)
    {
        _buildingCostUpgrade = building.gameObject.GetComponent<BuildingData>().BuildinCostUpgrade;

        if (_wallet.SpendMetal(_buildingCostUpgrade))
        {
            UpgradeBuidlding(building);
        }
        else
        {
            //вывести плашку, что не хватило средств
        }
    }

    public void UpgradeBuidlding(IUpgradeable building)
    {
        building.Upgrade();
        _view.HideUpgradeOptions();
    }
}