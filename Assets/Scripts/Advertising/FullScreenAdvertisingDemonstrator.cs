using System.Collections;
using TMPro;
using UnityEngine;
using YG;

namespace Advertising
{
    public class FullScreenAdvertisingDemonstrator : MonoBehaviour
    {
        [SerializeField] private AdShowFullScreen _fullScreenAdPanel;
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private int _adShowInterval;

        private int _startTimerValue = 3;
        private int _timerIterationTime = 1;
        private bool _isCounterOn = false;
        private Coroutine _countTime;

        private void Start()
        {
            StartCountTime();
        }

        private void OnEnable()
        {
            YandexGame.CloseFullAdEvent += OnCloseFullAd;
        }

        private void OnDisable()
        {
            StopCountTime();
            YandexGame.CloseFullAdEvent -= OnCloseFullAd;
        }

        private void ShowFullScreenAd()
        {
            YandexGame.FullscreenShow();
            _fullScreenAdPanel.gameObject.SetActive(false);
        }

        private void StartCountTime()
        {
            StopCountTime();
            _isCounterOn = true;
            _countTime = StartCoroutine(CountTime());
        }

        private void StopCountTime()
        {
            if (_countTime != null)
            {
                _isCounterOn = false;
                StopCoroutine(_countTime);
            }
        }

        private IEnumerator CountTime()
        {
            var waitForSeconds = new WaitForSeconds(_adShowInterval);
            int tempTimerValue;
            var waitForSecondsTimer = new WaitForSecondsRealtime(_timerIterationTime);

            while (_isCounterOn)
            {
                yield return waitForSeconds;
                Time.timeScale = 0;
                _fullScreenAdPanel.gameObject.SetActive(true);
                tempTimerValue = _startTimerValue;

                while (tempTimerValue > 0)
                {
                    _timerText.text = tempTimerValue.ToString();
                    yield return waitForSecondsTimer;
                    tempTimerValue--;
                }

                ShowFullScreenAd();
            }
        }

        private void OnCloseFullAd()
        {
            Time.timeScale = 1;
        }
    }
}