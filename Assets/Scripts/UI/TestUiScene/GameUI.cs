using System;
using UnityEngine;
using UnityEngine.UI;

namespace TestUiScene
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private Button _winButton;
        [SerializeField] private Button _loseButton;
        [SerializeField] private Button _turretsButton;
        [SerializeField] private Button _defaultButton;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Button _defaultButtonWinPanel;
        [SerializeField] private Button _defaultButtonTurretsPanel;
        [SerializeField] private Button _upgradeButtonUpgradePanel;
        [SerializeField] private GameObject _defaultPanel;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _turretsPanel;
        [SerializeField] private GameObject _upgradePanel;
        [SerializeField] private GameObject[] _panels;

        private void OnEnable()
        {
            _winButton.onClick.AddListener(OnWinButtonClick);
            _loseButton.onClick.AddListener(OnLoseButtonClick);
            _turretsButton.onClick.AddListener(OnTurretsButtonClick);
            _defaultButton.onClick.AddListener(OnDefaultButtonClick);
            _defaultButtonWinPanel.onClick.AddListener(OnDefaultButtonClick);
            _defaultButtonTurretsPanel.onClick.AddListener(OnDefaultButtonClick);
            _upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
            _upgradeButtonUpgradePanel.onClick.AddListener(OnDefaultButtonClick);
        }

        private void OnDisable()
        {
            _winButton.onClick.RemoveListener(OnWinButtonClick);
            _loseButton.onClick.RemoveListener(OnLoseButtonClick);
            _turretsButton.onClick.RemoveListener(OnTurretsButtonClick);
            _defaultButton.onClick.RemoveListener(OnDefaultButtonClick);
            _defaultButtonWinPanel.onClick.RemoveListener(OnDefaultButtonClick);
            _defaultButtonTurretsPanel.onClick.RemoveListener(OnDefaultButtonClick);
            _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClick);
            _upgradeButtonUpgradePanel.onClick.RemoveListener(OnDefaultButtonClick);
        }

        private void OnUpgradeButtonClick()
        {
            HideAllPanels();
            _upgradePanel.SetActive(true);
        }

        private void OnDefaultButtonClick()
        {
            HideAllPanels();
            _defaultPanel.SetActive(true);
        }

        private void OnTurretsButtonClick()
        {
            HideAllPanels();
            _turretsPanel.SetActive(true);
        }

        private void OnWinButtonClick()
        {
            HideAllPanels();
            _winPanel.SetActive(true);
        }

        private void OnLoseButtonClick()
        {
            HideAllPanels();
            _losePanel.SetActive(true);
        }

        private void HideAllPanels()
        {
            if(_panels.Length > 0)
            {
                foreach (GameObject panel in _panels)
                {
                    panel.gameObject.SetActive(false);
                }
            }
        }
    }
}