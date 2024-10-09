using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Screen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _panel;

        [SerializeField] protected Button _exitButton;
        [SerializeField] protected Button _restartButton;

        public event Action RestartButtonClick;

        public event Action ExitButtonClick;

        private void Awake()
        {
            _panel = GetComponent<CanvasGroup>();
        }

        protected void OnRestartButton()
        {
            RestartButtonClick?.Invoke();
        }

        protected void OnExitButton()
        {
            ExitButtonClick?.Invoke();
        }

        protected void OpenScreen()
        {
            _panel.blocksRaycasts = true;
            _panel.alpha = 1;
            Time.timeScale = 0;
        }

       protected void CloseScreen()
        {
            _panel.blocksRaycasts = false;
            _panel.alpha = 0;
            Time.timeScale = 1;
        }

       protected void OnOpen()
       {
            OpenScreen();
       }

       protected void OnClose()
       {
            CloseScreen();
       }
    }
}