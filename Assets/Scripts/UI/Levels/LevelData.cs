using TMPro;
using UnityEngine;

namespace Ui
{
    [CreateAssetMenu(fileName = "New Level", menuName = "Level/Create new level", order = 52)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int _id = 0;
        [SerializeField] private int _sceneIndex = 0;
        [SerializeField] private TMP_Text _levelInfo;
        [SerializeField] private TMP_Text _levelName;
        [SerializeField] private Sprite _levelImage;
        [SerializeField] private LevelView _template;

        public int Id => _id;

        public int SceneIndex => _sceneIndex;

        public Sprite LevelImage => _levelImage;

        public LevelView Template => _template;

        public TMP_Text LevelInfo => _levelInfo;

        public TMP_Text LevelName => _levelName;
    }
}