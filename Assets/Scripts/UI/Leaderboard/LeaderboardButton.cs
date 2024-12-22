using UnityEngine.UI;
using UnityEngine;

namespace UI.Leaderboard
{
    [RequireComponent(typeof(Button))]
    public class LeaderboardButton : MonoBehaviour
    {
        [SerializeField] private LeaderboardPanel _leaderboardPanel;

        private Button _leaderboardButton;

        private void Awake()
        {
            _leaderboardButton = GetComponent<Button>();
            _leaderboardButton.onClick.AddListener(OnLeaderboardButtonClick);
        }

        private void OnDisable()
        {
            _leaderboardButton.onClick.RemoveListener(OnLeaderboardButtonClick);
        }

        private void OnLeaderboardButtonClick()
        {
            _leaderboardPanel.gameObject.SetActive(true);
        }
    }
}