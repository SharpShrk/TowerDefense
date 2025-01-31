using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial
{
    public class TutorialLevel : MonoBehaviour
    {
        [SerializeField] private TutorialPanel _tutorialPanel;
        [SerializeField] private Button _nextButton;
        [SerializeField] private List<TutorialText> _tutorialTexts;
        [SerializeField] private Canvas _pointerCanvas;
        [SerializeField] private Canvas _walletCanvas;

        private int _currentText = 0;

        private void OnEnable()
        {
            _nextButton.onClick.AddListener(OnNextButtonClick);
            _tutorialTexts[_currentText].gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            _nextButton.onClick.RemoveListener(OnNextButtonClick);
        }

        private void HideCurrentText()
        {
            foreach (var tutorial in _tutorialTexts)
            {
                if (tutorial.gameObject.activeSelf)
                {
                    tutorial.gameObject.SetActive(false);
                }
            }
        }

        private void OnNextButtonClick()
        {
            HideCurrentText();

            if (_currentText >= _tutorialTexts.Count - 1)
            {
                _tutorialPanel.gameObject.SetActive(false);
                _pointerCanvas.gameObject.SetActive(true);
                _walletCanvas.gameObject.SetActive(true);
            }
            else
            {
                _currentText++;
                _tutorialTexts[_currentText].gameObject.SetActive(true);
            }
        }
    }
}