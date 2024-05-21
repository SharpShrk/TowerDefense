using UnityEngine;

public class UpgradePresenter: MonoBehaviour
{
    [SerializeField] private UpgradeView _view;

    public void OnBuildingSelected(GameObject building)
    {
        var upgradeable = building.GetComponent<IUpgradeable>();

        _view.ShowUpgradeOptions(upgradeable);
    }

    public void UpgradeBuilding(IUpgradeable building)
    {
        building.Upgrade();
        _view.HideUpgradeOptions();
    }
}