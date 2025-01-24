using System;
using Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class SceneLoader : MonoBehaviour
    {
        private const int MainMenuIndex = 0;

        [SerializeField] private SceneFader _sceneFader;
        [SerializeField] private SaveSystem _saveSystem;
        [SerializeField] private VictoryScreen _victoryScreen;
        [SerializeField] private DefeatScreen _defeatScreen;
        [SerializeField] private PauseScreen _pauseScreen;

        private int _currentScene;
        private int _nextScene;
        private int _levelsOpen;
        private int _maxLevelScene = 12;
        private int _numberOne = 1;

        private void OnEnable()
        {
            _victoryScreen.RestartButtonClick += OnNextLevel;
            _victoryScreen.ExitButtonClick += OnExitButtonClickVictory;
            _victoryScreen.Winned += OnWinned;
            _pauseScreen.RestartButtonClick += OnRestarButtonClick;
            _pauseScreen.ExitButtonClick += OnExitButtonClick;

            _defeatScreen.RestartButtonClick += OnRestarButtonClick;
            _defeatScreen.ExitButtonClick += OnExitButtonClick;
        }

        private void OnDisable()
        {
            _victoryScreen.RestartButtonClick -= OnNextLevel;
            _victoryScreen.ExitButtonClick -= OnExitButtonClickVictory;
            _victoryScreen.Winned -= OnWinned;
            _pauseScreen.RestartButtonClick -= OnRestarButtonClick;
            _pauseScreen.ExitButtonClick -= OnExitButtonClick;

            _defeatScreen.RestartButtonClick -= OnRestarButtonClick;
            _defeatScreen.ExitButtonClick -= OnExitButtonClick;
        }

        private void Start()
        {
            _currentScene = SceneManager.GetActiveScene().buildIndex;
            _nextScene = _currentScene + _numberOne;
            _levelsOpen = _saveSystem.LoadLevel();
        }

        private void OnRestarButtonClick()
        {
            _sceneFader.FadeTo(_currentScene);
        }

        private void OnExitButtonClick()
        {
            _saveSystem.SaveLevel(_nextScene, _levelsOpen);

            _sceneFader.FadeTo(MainMenuIndex);
        }

        private void OnExitButtonClickVictory()
        {
            _saveSystem.SaveLevel(_nextScene, _levelsOpen);
            _sceneFader.FadeTo(MainMenuIndex);
        }

        private void OnNextLevel()
        {
            if (_maxLevelScene == _currentScene)
            {
                _sceneFader.FadeTo(MainMenuIndex);
            }
            else
            {
                _saveSystem.SaveLevel(_nextScene, _levelsOpen);
                _sceneFader.FadeTo(_nextScene);
            }
        }

        private void OnWinned()
        {
            _saveSystem.SaveLevel(_nextScene, _levelsOpen);
        }
    }
}