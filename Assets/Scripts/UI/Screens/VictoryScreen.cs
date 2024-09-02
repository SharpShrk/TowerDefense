using System;
using EnemyLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class VictoryScreen : Screen
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private EnemyHandler _enemyHandler;
        [SerializeField] private HandlerUI _handlerUI;

        public event Action RestartButtonClick;

        public event Action ExitButtonClick;

        private void OnEnable()
        {
            _enemyHandler.AllEnemiesKilled += OpenVictoryScreen;

            _restartButton.onClick.AddListener(OnRestartButton);
            _exitButton.onClick.AddListener(OnExitButton);

            _handlerUI.OpenAfterFightVictoryClick += OnClose;
        }

        private void OnDisable()
        {
            _enemyHandler.AllEnemiesKilled -= OpenVictoryScreen;

            _restartButton.onClick.RemoveListener(OnRestartButton);
            _exitButton.onClick.RemoveListener(OnExitButton);

            _handlerUI.OpenAfterFightVictoryClick -= OnClose;
        }

        private void OpenVictoryScreen()
        {
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