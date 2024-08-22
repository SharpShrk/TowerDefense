using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class PauseScreen : Screen
    {
        [SerializeField] private Button _exitButton;

        [SerializeField] private HandlerUI _handlerUI;

        public event Action ExitButtonClick;

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(OnExitButton);
            _handlerUI.OpenPauseMenu += OnOpen;
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(OnExitButton);
            _handlerUI.OpenPauseMenu -= OnOpen;
        }

        private void OnExitButton()
        {
            ExitButtonClick?.Invoke();
            CloseScreen();
        }

        private void OnOpen()
        {
            OpenScreen();
        }
    }
}