using UnityEngine;
using UnityEngine.UI;

namespace UI.Leaderboard
{
    public class LeaderboardPanel : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            gameObject.SetActive(false);
        }
    }
}