using UnityEngine;
using Wallets;

namespace LogicGame
{
    public class SaveSystem : MonoBehaviour
    {
        private const string AllScore = "AllScore";
        protected const string Level = "Level";

        [SerializeField] private Score _score;

        private int _startNumberLevel = 1;
        private int _zero = 0;

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
                    SaveLevel(levelsOpen);
                }
            }

            SaveScore();
        }

        private void SaveLevel(int index)
        {
            PlayerPrefs.SetInt(Level, index);
        }

        private void SaveScore()
        {
            PlayerPrefs.SetInt(AllScore, _score.AllScore);
        }
    }
}