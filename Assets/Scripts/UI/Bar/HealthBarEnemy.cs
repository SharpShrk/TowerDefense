using System.Collections;
using EnemyLogic;
using UnityEngine;

namespace Ui
{
    public class HealthBarEnemy : Bar
    {
        [SerializeField] private EnemyHealth _enemyHealth;

        private WaitForSeconds _waitForSecounds;
        private float _delayBeforeHide = 2f;
        private Coroutine _hideCoroutine;

        private void OnEnable()
        {
            Slider.value = 1;
            Slider.gameObject.SetActive(false);
            _enemyHealth.HealthChanged += OnSliderChanger;
        }

        private void OnDisable()
        {
            _enemyHealth.HealthChanged -= OnSliderChanger;
        }

        private void Start()
        {
            _waitForSecounds = new WaitForSeconds(_delayBeforeHide);
        }

        private void OnSliderChanger(int value, int maxValue)
        {
            Slider.gameObject.SetActive(true);
            OnValueChanger(value, maxValue);
            StartHide();
        }

        private void StartHide()
        {
            if (_hideCoroutine != null)
            {
                StopCoroutine(_hideCoroutine);
            }

            _hideCoroutine = StartCoroutine(HideSlider());
        }

        private IEnumerator HideSlider()
        {
            yield return _waitForSecounds;
            Slider.gameObject.SetActive(false);
        }
    }
}