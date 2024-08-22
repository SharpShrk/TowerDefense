using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class MainScreen : Screen
    {
        [SerializeField] private Button _pauseButton;

        public event Action PauseButtonClick;

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(OnPauseButton);
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(OnPauseButton);
        }

        private void OnPauseButton()
        {
            PauseButtonClick?.Invoke();
        }
    }
}