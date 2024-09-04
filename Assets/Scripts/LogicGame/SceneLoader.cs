using Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class SceneLoader : MonoBehaviour
    {
        private const string MainMenu = "MainMenu";

        [SerializeField] private SceneFader _sceneFader;
        [SerializeField] private VictoryScreen _victoryScreen;
        [SerializeField] private DefeatScreen _defeatScreen;
        [SerializeField] private PauseScreen _pauseScreen;

        private string _currentScene;

        private void OnEnable()
        {
            _victoryScreen.RestartButtonClick += OnRestarButtonClick;
            _victoryScreen.ExitButtonClick += OnExitButtonClick;

            _pauseScreen.RestartButtonClick += OnRestarButtonClick;
            _pauseScreen.ExitButtonClick += OnExitButtonClick;

            _defeatScreen.RestartButtonClick += OnRestarButtonClick;
            _defeatScreen.ExitButtonClick += OnExitButtonClick;
        }

        private void OnDisable()
        {
            _victoryScreen.RestartButtonClick -= OnRestarButtonClick;
            _victoryScreen.ExitButtonClick -= OnExitButtonClick;

            _pauseScreen.RestartButtonClick -= OnRestarButtonClick;
            _pauseScreen.ExitButtonClick -= OnExitButtonClick;

            _defeatScreen.RestartButtonClick -= OnRestarButtonClick;
            _defeatScreen.ExitButtonClick -= OnExitButtonClick;
        }

        private void Start()
        {
            _currentScene = SceneManager.GetActiveScene().name;
        }

        private void OnRestarButtonClick()
        {
            _sceneFader.FadeTo(_currentScene);
        }

        private void OnExitButtonClick()
        {
            _sceneFader.FadeTo(MainMenu);
        }
    }
}