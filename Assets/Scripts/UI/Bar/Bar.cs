using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public abstract class Bar : MonoBehaviour
    {
        [SerializeField] private float _rateChange = 0.04f;
        [SerializeField] protected Slider Slider;

        private float _currentValue;
        private float _nextValue;
        private Coroutine _activeCoroutine;

        protected void OnValueChanger(int value, int maxValue)
        {
            _currentValue = Slider.value;
            _nextValue = (float)value / maxValue;

            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }

            _activeCoroutine = StartCoroutine(SmoothUpdate(_nextValue));
        }

        private IEnumerator SmoothUpdate(float value)
        {
            while (_currentValue != value)
            {
                Slider.value = Mathf.MoveTowards(Slider.value, value, _rateChange * Time.deltaTime);
                yield return null;
            }
        }
    }
}