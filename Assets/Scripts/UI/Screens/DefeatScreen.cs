using System;
using EnemyLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class DefeatScreen : Screen
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private HealthContainer _healthContainer;
        [SerializeField] private HandlerUI _handlerUI;

        public event Action RestartButtonClick;

        public event Action ExitButtonClick;

        public event Action DestroyEnemies;

        private void OnEnable()
        {
            _healthContainer.Died += OpenDefeatScreen;

            _restartButton.onClick.AddListener(OnRestartButton);
            _exitButton.onClick.AddListener(OnExitButton);

            _handlerUI.OpenAfterFightDefeatClick += OnClose;
        }

        private void OnDisable()
        {
            _healthContainer.Died -= OpenDefeatScreen;

            _restartButton.onClick.RemoveListener(OnRestartButton);
            _exitButton.onClick.RemoveListener(OnExitButton);

            _handlerUI.OpenAfterFightDefeatClick -= OnClose;
        }

        private void OpenDefeatScreen()
        {
            DestroyEnemies?.Invoke();
            OpenScreen();
        }

        private void OnRestartButton()
        {
            RestartButtonClick?.Invoke();
        }

        private void OnExitButton()
        {
            ExitButtonClick?.Invoke();
        }

        private void OnClose()
        {
            CloseScreen();
        }

    }
}