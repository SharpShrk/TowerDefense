using System.Collections;
using EnemyLogic;
using EnemyLogic.StateMachine.State;
using UnityEngine;

namespace UI.Bars
{
    public class HealthBarEnemy : Bar
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] protected DieState _dieState;
        
        private WaitForSeconds _waitForSecounds;
        private float _delayBeforeHide = 2f;
        private float _hideLimit = 0.1f;
        private Coroutine _hideCoroutine;
        private Camera _myCamera;

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
            _myCamera = Camera.main;
        }

        private void Update()
        {
            gameObject.transform.LookAt(transform.position + _myCamera.transform.rotation * Vector3.back, _myCamera.transform.rotation * Vector3.down);
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