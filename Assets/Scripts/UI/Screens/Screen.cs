using UnityEngine;

namespace Ui
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _panel;

        private void Awake()
        {
            _panel = GetComponent<CanvasGroup>();
        }

        public void OpenScreen()
        {
            _panel.blocksRaycasts = true;
            _panel.alpha = 1;
            Time.timeScale = 0;
        }

        public void CloseScreen()
        {
            _panel.blocksRaycasts = false;
            _panel.alpha = 0;
            Time.timeScale = 1;
        }
    }
}