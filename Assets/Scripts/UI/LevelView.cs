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
        private LevelConfig _levelData;

        public Button ButtonLevel => _buttonLevel;

        private void OnEnable()
        {
            _buttonLevel.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _buttonLevel.onClick.RemoveListener(OnButtonClick);
        }

        public void RenderLevelText(LevelConfig level)
        {
            _levelText.text = level.Id.ToString();
        }

        public void Init(LevelSelected levelSelected, LevelConfig levelData)
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