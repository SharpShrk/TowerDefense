using EnemyLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Wallets;

namespace Buildings.Upgrades.MainBaseUpgrade
{
    public class MainBaseUpgrader : MonoBehaviour
    {
        [SerializeField] private EnemyTargetHealth _enemyTargetHealth;
        [SerializeField] private MainBaseUpgradeData _upgradeData;
        [SerializeField] private EnergyWallet _wallet;
        [SerializeField] private int _costUpgrade;
        [SerializeField] private GameObject _upgradePanel;
        [SerializeField] private TMP_Text _costUpgradeText;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _upgradeButtonText;
        [SerializeField] private TMP_Text _notEnoughEnergyText;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private UpgradePanelStatusChecker _upgradeStatusChecker;

        private int _level = 1;
        private int _maxLevel = 3;

        private void Awake()
        {
            var upgradeLevelData = _upgradeData.Levels[_level - 1];

            _enemyTargetHealth.SetStartHealth(upgradeLevelData.Health);
        }

        private void OnEnable()
        {
            _upgradeButton.onClick.AddListener(TryUpgrade);
            _closeButton.onClick.AddListener(CloseUpgradePanel);
        }

        private void OnDisable()
        {
            _upgradeButton.onClick?.RemoveListener(TryUpgrade);
            _closeButton.onClick?.RemoveListener(CloseUpgradePanel);
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if(_upgradeStatusChecker.CanOpenNewPanel())
            {
                OpenUpgradePanel();               
            }
        }

        private void OpenUpgradePanel()
        {
            _costUpgradeText.text = _costUpgrade.ToString();
            _levelText.text = _level.ToString();

            SetUpgradeButtonState();
            _upgradePanel.SetActive(true);

            _upgradeStatusChecker.SetPanelOpen();
        }

        private void TryUpgrade()
        {
            if (_wallet.SpendResource(_costUpgrade))
            {
                ApplyUpgrade();
                CloseUpgradePanel();
            }
            else
            {
                CloseUpgradePanel();
            }
        }

        private void SetUpgradeButtonState()
        {
            if (_wallet.CurrentValue < _costUpgrade)
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

        private void CloseUpgradePanel()
        {
            _upgradePanel.SetActive(false);
            _upgradeStatusChecker.SetPanelClosed();
        }

        private void ApplyUpgrade()
        {
            if (_level < _maxLevel)
            {
                _level++;
            }

            if (_level <= _upgradeData.Levels.Length)
            {
                var upgradeLevelData = _upgradeData.Levels[_level - 1];

                _enemyTargetHealth.SetMaxHealth(upgradeLevelData.Health);
            }
        }
    }
}