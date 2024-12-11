using EnemyLogic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Wallets;

namespace MainBaseUpgrade 
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
        [SerializeField] private Button _upgradeButton;

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
        }

        private void OnDisable()
        {
            _upgradeButton.onClick?.RemoveListener(TryUpgrade);
        }

        private void OnMouseDown()
        {
            OpenUpgradePanel();
        }

        private void OpenUpgradePanel()
        {
            _costUpgradeText.text = _costUpgrade.ToString();
            _levelText.text = _level.ToString();
            _upgradePanel.SetActive(true);
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

        private void CloseUpgradePanel()
        {
            _upgradePanel.SetActive(false);
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