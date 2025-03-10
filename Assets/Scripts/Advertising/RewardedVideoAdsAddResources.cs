using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Wallets;
using YG;

namespace Advertising
{
    [RequireComponent(typeof(Button))]
    public class RewardedVideoAdsAddResources : MonoBehaviour
    {
        [SerializeField] private int _metalAdditionValue;
        [SerializeField] private int _energyAdditionValue;
        [SerializeField] private TMP_Text _metalAdditionText;
        [SerializeField] private TMP_Text _energyAdditionText;
        [SerializeField] private Notifier _errorVideoEventText;
        [SerializeField] private ResourceWallet _energyWallet;
        [SerializeField] private ResourceWallet _metalWallet;

        private Button _addResourcesButton;
        private int _advertisingId = 0;

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += OnRewarded;
            YandexGame.ErrorVideoEvent += OnErrorVideoEvent;
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= OnRewarded;
            YandexGame.ErrorVideoEvent -= OnErrorVideoEvent;
        }

        private void Awake()
        {
            _addResourcesButton = GetComponent<Button>();
            _addResourcesButton.onClick.AddListener(Show);
            _metalAdditionText.text = _metalAdditionValue.ToString();
            _energyAdditionText.text = _energyAdditionValue.ToString();
        }

        private void Show()
        {
            YandexGame.RewVideoShow(_advertisingId);
        }

        private void OnRewarded(int id)
        {
            if (id == _advertisingId)
            {
                _metalWallet.AddResource(_metalAdditionValue);
                _energyWallet.AddResource(_energyAdditionValue);
            }
        }

        private void OnErrorVideoEvent()
        {
            _errorVideoEventText.gameObject.SetActive(true);
        }
    }
}