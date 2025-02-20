using TMPro;
using UnityEngine;

namespace UI.Levels
{
    public class LevelConfig : MonoBehaviour
    {
        [SerializeField] private int _id = 0;
        [SerializeField] private int _sceneIndex = 0;
        [SerializeField] private TMP_Text _levelNameStorage;
        [SerializeField] private TMP_Text _levelInfoStorage;
        [SerializeField] private Sprite _levelImageStorage;
        [SerializeField] private LevelView _template;

        public int Id => _id;

        public int SceneIndex => _sceneIndex;

        public Sprite LevelImage => _levelImageStorage;

        public LevelView Template => _template;

        public TMP_Text LevelInfo => _levelInfoStorage;

        public TMP_Text LevelName => _levelNameStorage;
    }
}