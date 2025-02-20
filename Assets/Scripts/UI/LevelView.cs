using LogicGame;
using TMPro;
using UI.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private Button _buttonLevel;

        private LevelSelected _levelSelected;
        private LevelData _levelData;

        public Button ButtonLevel => _buttonLevel;

        private void OnEnable()
        {
            _buttonLevel.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _buttonLevel.onClick.RemoveListener(OnButtonClick);
        }

        public void RenderLevelText(LevelData level)
        {
            _levelText.text = level.Id.ToString();
        }

        public void Init(LevelSelected levelSelected, LevelData levelData)
        {
            _levelSelected = levelSelected;
            _levelData = levelData;
        }

        private void OnButtonClick()
        {
            _levelSelected.ShowLevel(_levelData);
            _levelSelected.PlayButtonClick += OnPlayButtonClick;
        }

        private void OnPlayButtonClick()
        {
            _levelSelected.LoadLevel(_levelData);
            _levelSelected.PlayButtonClick -= OnPlayButtonClick;
        }
    }
}