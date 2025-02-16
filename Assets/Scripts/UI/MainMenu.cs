using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : Screens.Screen
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;

        public Action OpenButtonClick;

        public Action SettingsButtonClick;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButton);
            _settingsButton.onClick.AddListener(OnSettingsButton);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButton);
            _settingsButton.onClick.RemoveListener(OnSettingsButton);
        }

        private void OnPlayButton()
        {
            OpenButtonClick?.Invoke();
        }

        private void OnSettingsButton()
        {
            SettingsButtonClick?.Invoke();
        }
    }
}