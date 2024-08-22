using System;
using UnityEngine;

namespace Ui
{
    public class HandlerUI : MonoBehaviour
    {
        [SerializeField] private MainScreen _mainScreen;

        public event Action OpenPauseMenu;

        private void OnEnable()
        {
            _mainScreen.PauseButtonClick += OnPauseScreen;
        }

        private void OnDisable()
        {
            _mainScreen.PauseButtonClick -= OnPauseScreen;
        }

        private void OnPauseScreen()
        {
            OpenPauseMenu?.Invoke();
        }
    }
}