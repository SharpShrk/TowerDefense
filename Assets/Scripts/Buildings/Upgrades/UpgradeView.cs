using Interfaces;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Wallets;

namespace Buildings.Upgrades
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private GameObject _upgradePanel;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _cost;
        [SerializeField] private TMP_Text _turretUpgradeParametersDescription;
        [SerializeField] private TMP_Text _factoryUpgradeParametersDescription;
        [SerializeField] private UpgradePresenter _upgradePresenter;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private TMP_Text _upgradeButtonText;
        [SerializeField] private TMP_Text _notEnoughEnergyText;
        [SerializeField] private Button _closeUpgradePanelButton;
        [SerializeField] private Notifier _maxLevelNotification;
        [SerializeField] private ResourceWallet _energyWallet;
        [SerializeField] private UpgradePanelStatusChecker _upgradeStatusChecker;

        private IUpgradeable _currentUpgradeableObject;
        private BuildingData _currentBuildingData;

        private void Awake()
        {
            _energyWallet.ValueChanged += OnEnergyValueChanged;
        }

        private void OnEnable()
        {
            _upgradeButton.onClick.AddListener(OnButtonUpgradeClick);
            _closeUpgradePanelButton.onClick.AddListener(HideUpgradeOptions);
        }

        private void OnDisable()
        {
            _upgradeButton.onClick?.RemoveListener(OnButtonUpgradeClick);
            _closeUpgradePanelButton.onClick.AddListener(HideUpgradeOptions);
            _energyWallet.ValueChanged -= OnEnergyValueChanged;
        }

        public void ShowUpgradeOptions(IUpgradeable upgradeable)
        {
            if (_upgradePanel.activeSelf || !_upgradeStatusChecker.CanOpenNewPanel())
            {
                return;
            }

            _upgradeStatusChecker.SetPanelOpen();
            _currentUpgradeableObject = upgradeable;
            _currentBuildingData = _currentUpgradeableObject.gameObject.GetComponent<BuildingData>();
            _level.text = _currentBuildingData.BuidlingLevel.ToString();
            _cost.text = _currentBuildingData.BuildinCostUpgrade.ToString();

            switch (_currentBuildingData)
            {
                case TurretData turretData:
                    _turretUpgradeParametersDescription.enabled = true;
                    _factoryUpgradeParametersDescription.enabled = false;
                    break;
                case ResourcesFactoryData factoryData:
                    _turretUpgradeParametersDescription.enabled = false;
                    _factoryUpgradeParametersDescription.enabled = true;
                    break;
                default:
                    break;
            }

            if (_currentBuildingData.BuidlingLevel < _currentBuildingData.BuidingMaxLevel)
            {
                _upgradePanel.SetActive(true);
                SetUpgradeButtonState(_energyWallet.CurrentValue);
            }
            else
            {
                _maxLevelNotification.gameObject.SetActive(true);
                _upgradeStatusChecker.SetPanelClosed();
            }
        }

        public void HideUpgradeOptions()
        {
            _upgradeStatusChecker.SetPanelClosed();
            _upgradePanel?.SetActive(false);
        }

        private void OnButtonUpgradeClick()
        {
            _upgradePresenter.TryUpgradeBuilding(_currentUpgradeableObject);
        }

        private void SetUpgradeButtonState(int energyValue)
        {
            if (energyValue < _currentBuildingData.BuildinCostUpgrade)
            {
                _upgradeButton.interactable = false;
                _upgradeButtonText.gameObject.SetActive(false);
                _notEnoughEnergyText.gameObject.SetActive(true);
            }
            else
            {
                _upgradeButton.interactable = true;
                _upgradeButtonText.gameObject.SetActive(true);
                _notEnoughEnergyText.gameObject.SetActive(false);
            }
        }

        private void OnEnergyValueChanged(int energyValue)
        {
            if (_currentBuildingData != null)
            {
                SetUpgradeButtonState(energyValue);
            }
        }
    }
}