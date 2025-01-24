using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UI.Leaderboard
{
    public class AuthorizationPanel : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _authorizationButton;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClick);
            _authorizationButton.onClick.AddListener(OnAuthorizationButtonClick);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
            _authorizationButton.onClick.AddListener(OnAuthorizationButtonClick);
        }

        private void OnAuthorizationButtonClick()
        {
            YandexGame.AuthDialog();
            OnCloseButtonClick();
        }

        private void OnCloseButtonClick()
        {
            gameObject.SetActive(false);
        }
    }
}