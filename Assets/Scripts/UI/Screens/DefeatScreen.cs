using System;
using EnemyLogic;
using UnityEngine;

namespace Ui
{
    public class DefeatScreen : Screen
    {
        [SerializeField] private HealthContainer _healthContainer;
        [SerializeField] private HandlerUI _handlerUI;

        public event Action DestroyEnemies;

        private void OnEnable()
        {
            _healthContainer.Died += OpenDefeatScreen;
            _handlerUI.OpenAfterFightDefeatClick += OnClose;

            _restartButton.onClick.AddListener(OnRestartButton);
            _exitButton.onClick.AddListener(OnExitButton);
        }

        private void OnDisable()
        {
            _healthContainer.Died -= OpenDefeatScreen;
            _handlerUI.OpenAfterFightDefeatClick -= OnClose;

            _restartButton.onClick.RemoveListener(OnRestartButton);
            _exitButton.onClick.RemoveListener(OnExitButton);
        }

        private void OpenDefeatScreen()
        {
            DestroyEnemies?.Invoke();
            OpenScreen();
        }

        private void OnClose()
        {
            CloseScreen();
        }
    }
}