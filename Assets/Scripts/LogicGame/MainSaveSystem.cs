using UI;
using UnityEngine;

namespace LogicGame
{
    public class MainSaveSystem : SaveSystem
    {
        [SerializeField] private LevelSelected _levelSelected;

        private void Awake()
        {
            Load();
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

    }
}