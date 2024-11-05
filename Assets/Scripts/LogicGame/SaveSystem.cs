using UnityEngine;

namespace GameLogic
{
    public class SaveSystem : MonoBehaviour
    {
        private const string Level = "Level";

        [SerializeField] private LevelSelected _levelSelected;

        private int _startNumberLevel = 1;
        private int _zero;

        private void Awake()
        {
            Load();
        }

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

        private void Load()
        {
            if (PlayerPrefs.HasKey(Level))
            {
                if (_levelSelected != null)
                {
                    _levelSelected.InitLevel(PlayerPrefs.GetInt(Level));
                }
            }
        }

        private void ResetSave()
        {
            PlayerPrefs.SetInt(Level, _startNumberLevel);
        }
    }
}