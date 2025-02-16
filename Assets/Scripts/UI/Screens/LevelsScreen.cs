using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class LevelsScreen : Screen
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private MainMenu _mainMenu;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnClose);
            _mainMenu.OpenButtonClick += OnOpen;
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnClose);
            _mainMenu.OpenButtonClick -= OnOpen;
        }
    }
}