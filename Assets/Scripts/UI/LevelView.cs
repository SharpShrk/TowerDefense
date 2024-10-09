using GameLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
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
            _levelSelected.PlayButtonClick -= OnPlayButtonClick;
            _buttonLevel.onClick.RemoveListener(OnButtonClick);
        }

        private void Start()
        {
            _levelSelected.PlayButtonClick += OnPlayButtonClick;
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
        }

        private void OnPlayButtonClick()
        {
            _levelSelected.LoadLevel(_levelData);
        }
    }
}