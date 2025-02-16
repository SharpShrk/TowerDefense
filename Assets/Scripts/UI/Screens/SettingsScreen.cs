using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class SettingsScreen : Screen
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private MainMenu _mainMenu;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnClose);
            _mainMenu.SettingsButtonClick += OnOpen;
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnClose);
            _mainMenu.SettingsButtonClick -= OnOpen;
        }
    }
}