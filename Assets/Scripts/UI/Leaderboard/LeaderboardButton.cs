using UnityEngine.UI;
using UnityEngine;
using YG;

namespace UI.Leaderboard
{
    [RequireComponent(typeof(Button))]
    public class LeaderboardButton : MonoBehaviour
    {
        private const string LeaderboardName = "LeaderBoard1";
        private const string AllScore = "AllScore";

        [SerializeField] private LeaderboardPanel _leaderboardPanel;
        [SerializeField] private AuthorizationPanel _authorizationPanel;

        private int _exclusiveMinScore = 0;
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
            if (YandexGame.auth)
            {
                int score = PlayerPrefs.GetInt(AllScore);

                if (score > _exclusiveMinScore)
                {
                    YandexGame.NewLeaderboardScores(LeaderboardName, score);
                }

                _leaderboardPanel.gameObject.SetActive(true);
            }
            else
            {
                _authorizationPanel.gameObject.SetActive(true);
            }
        }
    }
}