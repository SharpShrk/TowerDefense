using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class PauseScreen : Screen
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private HandlerUI _handlerUI;

        public event Action CloseButtonClick;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnCloseButton);
            _handlerUI.OpenPauseMenu += OnOpen;
            _handlerUI.ClosePauseMenu += OnClose;

            _restartButton.onClick.AddListener(OnRestartButton);
            _exitButton.onClick.AddListener(OnExitButton);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnCloseButton);
            _handlerUI.OpenPauseMenu -= OnOpen;
            _handlerUI.ClosePauseMenu -= OnClose;

            _restartButton.onClick.RemoveListener(OnRestartButton);
            _exitButton.onClick.RemoveListener(OnExitButton);
        }

        private void OnCloseButton()
        {
            CloseButtonClick?.Invoke();
            CloseScreen();
        }
    }
}