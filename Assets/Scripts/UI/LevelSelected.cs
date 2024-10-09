using System;
using System.Collections.Generic;
using TMPro;
using Ui;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    public class LevelSelected : MonoBehaviour
    {
        [SerializeField] private List<LevelData> _levels;
        [SerializeField] private Transform _container;
        [SerializeField] private SceneFader _sceneFader;

        [SerializeField] private TMP_Text _textInfo;
        [SerializeField] private Button _playButton;
        [SerializeField] private Image _image;

        private int _levelReached = 2;//Временное решение

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

        public void ShowLevel(LevelData level)
        {
            HideLevel(true);
            _textInfo.text = level.Id.ToString();
            _image.sprite = level.LevelImage;
        }

        public void LoadLevel(LevelData levelData)
        {
            Time.timeScale = 1;
            _sceneFader.FadeTo(levelData.SceneIndex);
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

            if (level.Id < _levelReached)
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
