using System;
using UnityEngine;

namespace Ui
{
    public class HandlerUI : MonoBehaviour
    {
        [SerializeField] private MainScreen _mainScreen;
        [SerializeField] private PauseScreen _pauseScreen;
        [SerializeField] private DefeatScreen _defeatScreen;
        [SerializeField] private VictoryScreen _victoryScreen;

        public event Action OpenPauseMenu;

        public event Action ClosePauseMenu;

        public event Action OpenAfterFightVictoryClick;

        public event Action OpenAfterFightDefeatClick;

        private void OnEnable()
        {
            _mainScreen.PauseButtonClick += OnPauseScreen;
            _pauseScreen.RestartButtonClick += OnMenuPauseScreen;
            _pauseScreen.ExitButtonClick += OnMenuPauseScreen;
            _defeatScreen.RestartButtonClick += OnMenuFightScreen;
            _defeatScreen.ExitButtonClick += OnMenuFightScreen;

            _victoryScreen.RestartButtonClick += OnMenuAfterFightScreen;
            _victoryScreen.ExitButtonClick += OnMenuAfterFightScreen;
        }

        private void OnDisable()
        {
            _mainScreen.PauseButtonClick -= OnPauseScreen;
            _pauseScreen.RestartButtonClick -= OnMenuPauseScreen;
            _pauseScreen.ExitButtonClick -= OnMenuPauseScreen;
            _defeatScreen.RestartButtonClick -= OnMenuFightScreen;
            _defeatScreen.ExitButtonClick -= OnMenuFightScreen;

            _victoryScreen.RestartButtonClick -= OnMenuAfterFightScreen;
            _victoryScreen.ExitButtonClick -= OnMenuAfterFightScreen;
        }

        private void OnPauseScreen()
        {
            OpenPauseMenu?.Invoke();
        }

        private void OnMenuAfterFightScreen()
        {
            OpenAfterFightVictoryClick?.Invoke();
        }

        private void OnMenuFightScreen()
        {
            OpenAfterFightDefeatClick?.Invoke();
        }

        private void OnMenuPauseScreen()
        {
            ClosePauseMenu?.Invoke();
        }
    }
}