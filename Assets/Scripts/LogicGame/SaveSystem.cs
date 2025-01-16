using UnityEngine;
using Wallets;
using YG;

namespace GameLogic
{
    public class SaveSystem : MonoBehaviour
    {
        private const string LeaderboardName = "LB";
        private const string AllScore = "AllScore";
        protected const string Level = "Level";

        [SerializeField] private Score _score;

        private int _startNumberLevel = 1;
        private int _zero =0;

        public int LoadLevel()
        {
            if (PlayerPrefs.HasKey(Level))
            {
                _score.Init(PlayerPrefs.GetInt(AllScore));
                return PlayerPrefs.GetInt(Level);
            }
            
            return _startNumberLevel;
        }

        public void SaveLevel(int nextScene, int levelsOpen)
        {
            if (nextScene > _zero && levelsOpen > _zero)
            {
                if (nextScene > levelsOpen)
                {
                    levelsOpen++;
                    Save(levelsOpen);
                }
            }
        }

        private void Save(int index)
        {
            PlayerPrefs.SetInt(Level, index);
            PlayerPrefs.SetInt(AllScore, _score.AllScore);
            SaveLeaderboardScore(PlayerPrefs.GetInt(AllScore));
        }

        private void SaveLeaderboardScore(int value)
        {
            YandexGame.NewLeaderboardScores(LeaderboardName, value);
        }
    }
}