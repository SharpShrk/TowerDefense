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
    [SerializeField] private UpgradePresenter _upgradePresenter;
    [SerializeField] private Button _upgradeButton;

    private IUpgradeable _currentUpgradeableObject;

    private void OnEnable()
    {
        _upgradeButton.onClick.AddListener(OnButtonUpgradeClick);
    }

    private void OnDisable()
    {
        _upgradeButton.onClick?.RemoveListener(OnButtonUpgradeClick);
    }

    public void ShowUpgradeOptions(IUpgradeable upgradeable)
    {
        _currentUpgradeableObject = upgradeable;

        BuildingData buildingData = _currentUpgradeableObject.gameObject.GetComponent<BuildingData>();

        _label.text = buildingData.Label;
        _level.text = buildingData.Level.ToString();

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
