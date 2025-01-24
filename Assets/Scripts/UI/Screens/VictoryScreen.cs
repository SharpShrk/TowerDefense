using EnemyLogic;
using UnityEngine;
using UnityEngine.Events;

namespace Ui
{
    public class VictoryScreen : Screen
    {
        [SerializeField] private EnemyHandler _enemyHandler;
        [SerializeField] private HandlerUI _handlerUI;

        public event UnityAction Winned;

        private void OnEnable()
        {
            _enemyHandler.AllEnemiesKilled += OpenVictoryScreen;
            _handlerUI.OpenAfterFightVictoryClick += OnClose;
            _restartButton.onClick.AddListener(OnRestartButton);
            _exitButton.onClick.AddListener(OnExitButton);
        }

        private void OnDisable()
        {
            _enemyHandler.AllEnemiesKilled -= OpenVictoryScreen;
            _handlerUI.OpenAfterFightVictoryClick -= OnClose;

            _restartButton.onClick.RemoveListener(OnRestartButton);
            _exitButton.onClick.RemoveListener(OnExitButton);
        }

        private void OpenVictoryScreen()
        {
            OpenScreen();
            Winned?.Invoke();
        }
    }
}