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
        [SerializeField] private Button _defaultButtonWinPanel;
        [SerializeField] private Button _defaultButtonTurretsPanel;
        [SerializeField] private GameObject _defaultPanel;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _turretsPanel;
        [SerializeField] private GameObject[] _panels;

        private void OnEnable()
        {
            _winButton.onClick.AddListener(OnWinButtonClick);
            _loseButton.onClick.AddListener(OnLoseButtonClick);
            _turretsButton.onClick.AddListener(OnTurretsButtonClick);
            _defaultButton.onClick.AddListener(OnDefaultButtonClick);
            _defaultButtonWinPanel.onClick.AddListener(OnDefaultButtonClick);
            _defaultButtonTurretsPanel.onClick.AddListener(OnDefaultButtonClick);
        }

        private void OnDisable()
        {
            _winButton.onClick.RemoveListener(OnWinButtonClick);
            _loseButton.onClick.RemoveListener(OnLoseButtonClick);
            _turretsButton.onClick.RemoveListener(OnTurretsButtonClick);
            _defaultButton.onClick.RemoveListener(OnDefaultButtonClick);
            _defaultButtonWinPanel.onClick.RemoveListener(OnDefaultButtonClick);
            _defaultButtonTurretsPanel.onClick.RemoveListener(OnDefaultButtonClick);
        }

        private void OnDefaultButtonClick()
        {
            HideAllPanels();
            _defaultPanel.gameObject.SetActive(true);
        }

        private void OnTurretsButtonClick()
        {
            HideAllPanels();
            _turretsPanel.gameObject.SetActive(true);
        }

        private void OnWinButtonClick()
        {
            HideAllPanels();
            _winPanel.gameObject.SetActive(true);
        }

        private void OnLoseButtonClick()
        {
            HideAllPanels();
            _losePanel.gameObject.SetActive(true);
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