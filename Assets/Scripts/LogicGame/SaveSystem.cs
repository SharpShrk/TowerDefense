using UnityEngine;
using Wallets;

namespace GameLogic
{
    public class SaveSystem : MonoBehaviour
    {
        private const string AllScore = "AllScore";
        protected const string Level = "Level";

        [SerializeField] private Score _score;

        private int _startNumberLevel = 1;
        private int _startScore = 0;
        private int _zero;

        private void Start()
        {
            //ResetSave(); //Для тестов
        }

        //public void LoadScore()
        //{
        //    if (PlayerPrefs.HasKey(Level))
        //    {
        //        if (_score != null)
        //        {
        //            _score.Init(PlayerPrefs.GetInt(AllScore));
        //        }
        //    }
        //}

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
        }

        private void ResetSave()
        {
            PlayerPrefs.SetInt(Level, _startNumberLevel);
            PlayerPrefs.SetInt(AllScore, _startScore);
        }
    }
}