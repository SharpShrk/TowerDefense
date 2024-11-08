using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Abilities
{
    [RequireComponent(typeof(Button))]
    public abstract class Ability : MonoBehaviour
    {
        [SerializeField] private bool _isAvailableOnStart;
        [SerializeField] private bool _isAvailableOnLevel;
        [SerializeField] private float _rechargeTime;
        [SerializeField] private Image _lockImage;
        [SerializeField] private Image _abilityImage;
        [SerializeField] private Image _rechargeImage;
        [SerializeField] private Image _adImage;
        [SerializeField] private AudioSource _activationSound;
        [SerializeField] private bool _isActivatedAfterViewAd;
        [SerializeField] private int _advertisingId;
        [SerializeField] private ErrorVideoEventText _errorVideoEventText;

        private int _oneUpdateDuration = 1;
        private float _tempRechargeTime;
        private float _minTempRechargeTime = 0;
        private float _rechargeImageDefaultFill = 1;
        private Button _abilityButton;
        private Color _unavailableColor = new Color(1.0f, 1.0f, 1.0f, 0.35f);
        private Color _defaultColor = new Color(1.0f, 1.0f, 1.0f, 1f);
        private Coroutine _recharge;
        private bool _isRecharging = false;

        private void Awake()
        {
            _abilityButton = GetComponent<Button>();
            _abilityButton.onClick.AddListener(OnAbilityButtonClick);

            if (!_isAvailableOnLevel && _lockImage != null)
            {
                _lockImage.gameObject.SetActive(true);
                _abilityButton.interactable = false;
                _abilityImage.color = _unavailableColor;
                _isAvailableOnStart = false;
            }

            if (!_isAvailableOnStart && _isAvailableOnLevel)
            {
                StartRecharging();
            }

            if (_isActivatedAfterViewAd)
            {
                _rechargeTime = 0;
                _adImage.gameObject.SetActive(true);
            }
            else
            {
                _adImage.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += OnRewarded;
            YandexGame.ErrorVideoEvent += OnErrorVideoAdEvent;
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= OnRewarded;
            YandexGame.ErrorVideoEvent -= OnErrorVideoAdEvent;
            _abilityButton.onClick.RemoveListener(OnAbilityButtonClick);
            StopRecharging();
        }

        public virtual void OnAbilityButtonClick()
        {
            if (_isActivatedAfterViewAd)
            {
                YandexGame.RewVideoShow(_advertisingId);
            }
            else
            {
                Activate();
            }
        }

        public virtual void Activate()
        {
            _activationSound.PlayDelayed(0);
            StartRecharging();
        }

        private void TurnOn()
        {
            _abilityImage.color = _defaultColor;
            _abilityButton.interactable = true;
        }

        private void StartRecharging()
        {
            _abilityImage.color = _unavailableColor;
            _abilityButton.interactable = false;
            _rechargeImage.gameObject.SetActive(true);
            _isRecharging = true;
            StopRecharging();
            _recharge = StartCoroutine(Recharge());
        }

        private void StopRecharging()
        {
            if (_recharge != null)
            {
                StopCoroutine(_recharge);
            }
        }

        private IEnumerator Recharge()
        {
            _tempRechargeTime = _rechargeTime;
            var waitForSecond = new WaitForSeconds(_oneUpdateDuration);

            while (_isRecharging)
            {
                yield return waitForSecond;
                _tempRechargeTime--;
                _rechargeImage.fillAmount = _tempRechargeTime / _rechargeTime;

                if (_tempRechargeTime <= _minTempRechargeTime)
                {
                    TurnOn();
                    _isRecharging = false;
                }
            }

            _rechargeImage.gameObject.SetActive(false);
            _rechargeImage.fillAmount = _rechargeImageDefaultFill;
            StopRecharging();
        }

        private void OnRewarded(int id)
        {
            if (id == _advertisingId)
            {
                Activate();
            }
        }

        private void OnErrorVideoAdEvent()
        {
            _errorVideoEventText.gameObject.SetActive(true);
        }
    }
}