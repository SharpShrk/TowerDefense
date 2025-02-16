using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Abilities
{
    public class HintPanel : MonoBehaviour
    {
        [SerializeField] private Button _closeButtonSquare;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Image _curtain;
        [SerializeField] private Image _abilityImage;
        [SerializeField] private TMP_Text[] _abilityHintsText;
        [SerializeField] private Sprite[] _abilityHintsSprites;

        private int _initialIndex = 0;
        private int _currentIndex;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClick);
            _closeButtonSquare.onClick.AddListener(OnCloseButtonClick);
            _nextButton.onClick.AddListener(OnNextButtonClick);
            _curtain.gameObject.SetActive(true);
            _closeButton.gameObject.SetActive(false);
            _nextButton.gameObject.SetActive(true);
            HideActiveHints();
            _currentIndex = _initialIndex;
            _abilityHintsText[_currentIndex].gameObject.SetActive(true);
            _abilityImage.sprite = _abilityHintsSprites[_currentIndex];
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
            _closeButtonSquare.onClick.RemoveListener(OnCloseButtonClick);
            _nextButton.onClick.RemoveListener(OnNextButtonClick);
        }

        private void OnCloseButtonClick()
        {
            gameObject.SetActive(false);
            _curtain.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }

        private void OnNextButtonClick()
        {
            _abilityHintsText[_currentIndex].gameObject.SetActive(false);
            _currentIndex++;

            if (_currentIndex >= _abilityHintsText.Length - 1)
            {
                ShowNext();
                _nextButton.gameObject.SetActive(false);
                _closeButton.gameObject.SetActive(true);
            }
            else
            {
                ShowNext();
            }
        }

        private void ShowNext()
        {
            _abilityHintsText[_currentIndex].gameObject.SetActive(true);
            _abilityImage.sprite = _abilityHintsSprites[_currentIndex];
        }

        private void HideActiveHints()
        {
            foreach (var hint in _abilityHintsText)
            {
                if (hint.gameObject.activeSelf)
                {
                    hint.gameObject.SetActive(false);
                }
            }
        }
    }
}