using UnityEngine;

namespace GameLogic
{
    public class SaveSystem : MonoBehaviour
    {
        protected const string Level = "Level";

        private int _startNumberLevel = 1;
        private int _zero;

        private void Start()
        {
            //ResetSave(); //Для тестов
        }


        public int LoadLevel()
        {
            if (PlayerPrefs.HasKey(Level))
            {
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
        }

        private void ResetSave()
        {
            PlayerPrefs.SetInt(Level, _startNumberLevel);
        }
    }
}