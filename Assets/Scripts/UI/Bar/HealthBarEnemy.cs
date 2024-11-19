using System.Collections;
using EnemyLogic;
using UnityEngine;

namespace Ui
{
    public class HealthBarEnemy : Bar
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] protected DieState _dieState;
        
        private WaitForSeconds _waitForSecounds;
        private float _delayBeforeHide = 2f;
        private float _hideLimit = 0.1f;
        private Coroutine _hideCoroutine;

        private void OnEnable()
        {
            Slider.value = 1;
            Slider.gameObject.SetActive(false);
            _enemyHealth.HealthChanged += OnSliderChanger;
            _enemyHealth.Died += OnHideSliderBeforeDeth;
            _dieState.Died += OnHideSliderBeforeDeth;
        }

        private void OnDisable()
        {
            _enemyHealth.HealthChanged -= OnSliderChanger;
            _enemyHealth.Died -= OnHideSliderBeforeDeth;
            _dieState.Died -= OnHideSliderBeforeDeth;
        }

        private void Start()
        {
            _waitForSecounds = new WaitForSeconds(_delayBeforeHide);
        }

        private void OnSliderChanger(int value, int maxValue)
        {
            if (value < _hideLimit)
            {
                return;
            }

            OnValueChanger(value, maxValue);
            Slider.gameObject.SetActive(true);
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

        private void OnHideSliderBeforeDeth()
        {
            Slider.gameObject.SetActive(false);
        }
    }
}