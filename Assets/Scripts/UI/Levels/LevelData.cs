using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    [CreateAssetMenu(fileName = "New Level", menuName = "Level/Create new level", order = 52)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int _id = 0;
        [SerializeField] private int _sceneIndex = 0;
        [SerializeField] private Sprite _levelImage;
        [SerializeField] private LevelView _template;

        public int Id => _id;

        public int SceneIndex => _sceneIndex;

        public Sprite LevelImage => _levelImage;

        public LevelView Template => _template;
    }
}