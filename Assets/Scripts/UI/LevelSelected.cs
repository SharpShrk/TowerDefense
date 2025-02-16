using System;
using System.Collections.Generic;
using TMPro;
using UI.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelSelected : MonoBehaviour
    {
        [SerializeField] private List<LevelData> _levels;
        [SerializeField] private Transform _container;
        [SerializeField] private SceneFader _sceneFader;

        [SerializeField] private TMP_Text _textInfo;
        [SerializeField] private TMP_Text _textLevelName;
        [SerializeField] private Button _playButton;
        [SerializeField] private Image _image;

        private int _levelReached = 1;
        private int _numberOne = 1;

        public event Action PlayButtonClick;

        private void OnEnable()
        {
           _playButton.onClick.AddListener(OnPlayButtonClick);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClick);
        }

        private void Start()
        {
            CreateLevels();
            HideLevel(false);
        }

        public void InitLevel(int currentLevel)
        {
            if (currentLevel >= _numberOne)
            {
                _levelReached = currentLevel;
            }
            else
            {
                _levelReached = _numberOne;
            }
        }

        public void ShowLevel(LevelData level)
        {
            HideLevel(true);
            _textLevelName.text = level.LevelName.text;
            _textInfo.text = level.LevelInfo.text;
            _image.sprite = level.LevelImage;
            _playButton.onClick.AddListener(OnPlayButtonClick);
        }

        public void LoadLevel(LevelData levelData)
        {
            Time.timeScale = _numberOne;
            _sceneFader.FadeTo(levelData.SceneIndex);
            _playButton.onClick.RemoveListener(OnPlayButtonClick);
        }

        private void CreateLevels()
        {
            for (int i = 0; i < _levels.Count; i++)
            {
                AddLevel(_levels[i]);
            }
        }

        private void AddLevel(LevelData level)
        {
            var view = Instantiate(level.Template, _container);
            view.RenderLevelText(level);
            view.Init(this, level);

            if (level.SceneIndex <= _levelReached)
            {
                view.ButtonLevel.interactable = true;
            }
            else
            {
                view.ButtonLevel.interactable = false;
            }
        }

        private void OnPlayButtonClick()
        {
            PlayButtonClick?.Invoke();
        }

        private void HideLevel(bool value)
        {
            _image.gameObject.SetActive(value);
            _playButton.gameObject.SetActive(value);
        }
    }
}
