using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _turretUpgradeParametersDescription;
    [SerializeField] private TMP_Text _factoryUpgradeParametersDescription;
    [SerializeField] private UpgradePresenter _upgradePresenter;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _closeUpgradePanelButton;

    private IUpgradeable _currentUpgradeableObject;

    private void OnEnable()
    {
        _upgradeButton.onClick.AddListener(OnButtonUpgradeClick);
        _closeUpgradePanelButton.onClick.AddListener(HideUpgradeOptions);
    }

    private void OnDisable()
    {
        _upgradeButton.onClick?.RemoveListener(OnButtonUpgradeClick);
        _closeUpgradePanelButton.onClick.AddListener(HideUpgradeOptions);
    }

    public void ShowUpgradeOptions(IUpgradeable upgradeable)
    {
        _currentUpgradeableObject = upgradeable;

        BuildingData buildingData = _currentUpgradeableObject.gameObject.GetComponent<BuildingData>();

        _label.text = buildingData.BuidlingLabel;
        _level.text = buildingData.BuidlingLevel.ToString();

        if(buildingData is TurretData turretData)
        {
            _turretUpgradeParametersDescription.enabled = true;
            _factoryUpgradeParametersDescription.enabled = false;
        }
        else if(buildingData is ResourcesFactoryData factoryData)
        {
            _turretUpgradeParametersDescription.enabled = false;
            _factoryUpgradeParametersDescription.enabled = true;
        }

        _upgradePanel.SetActive(true);
    }

    public void HideUpgradeOptions()
    {
        _upgradePanel?.SetActive(false);
    }

    private void OnButtonUpgradeClick()
    {
        _upgradePresenter.UpgradeBuilding(_currentUpgradeableObject);
    }
}
