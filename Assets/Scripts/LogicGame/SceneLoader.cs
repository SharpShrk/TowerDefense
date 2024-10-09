using Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class SceneLoader : MonoBehaviour
    {
        private const int MainMenuIndex = 0;

        [SerializeField] private SceneFader _sceneFader;
        [SerializeField] private VictoryScreen _victoryScreen;
        [SerializeField] private DefeatScreen _defeatScreen;
        [SerializeField] private PauseScreen _pauseScreen;

        private int _currentScene;
        private int _maxLevelScene = 10;

        private void OnEnable()
        {
            _victoryScreen.RestartButtonClick += OnNextLevel;
            _victoryScreen.ExitButtonClick += OnExitButtonClick;

            _pauseScreen.RestartButtonClick += OnRestarButtonClick;
            _pauseScreen.ExitButtonClick += OnExitButtonClick;

            _defeatScreen.RestartButtonClick += OnRestarButtonClick;
            _defeatScreen.ExitButtonClick += OnExitButtonClick;
        }

        private void OnDisable()
        {
            _victoryScreen.RestartButtonClick -= OnNextLevel;
            _victoryScreen.ExitButtonClick -= OnExitButtonClick;

            _pauseScreen.RestartButtonClick -= OnRestarButtonClick;
            _pauseScreen.ExitButtonClick -= OnExitButtonClick;

            _defeatScreen.RestartButtonClick -= OnRestarButtonClick;
            _defeatScreen.ExitButtonClick -= OnExitButtonClick;
        }

        private void Start()
        {
            _currentScene = SceneManager.GetActiveScene().buildIndex;
        }

        private void OnRestarButtonClick()
        {
            _sceneFader.FadeTo(_currentScene);
        }

        private void OnExitButtonClick()
        {
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
                _sceneFader.FadeTo(_currentScene + 1);
            }
        }
    }
}