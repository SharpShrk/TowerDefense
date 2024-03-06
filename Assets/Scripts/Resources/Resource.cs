using System.Collections;
using UnityEngine;

namespace Resources
{
    [RequireComponent(typeof(ResourceAnimator))]
    public abstract class Resource : MonoBehaviour
    {
        [SerializeField] private int _volume;

        private ResourceAnimator _animator;
        private int _lifeTime = 6;
        private int _hideAnimationDuration = 1;
        private Coroutine _countLifeTime;

        public int Volume => _volume;

        private void Awake()
        {
            _animator = GetComponent<ResourceAnimator>();
        }

        private void OnEnable()
        {
            _countLifeTime = StartCoroutine(CountLifeTime());
        }

        private void OnDisable()
        {
            if(_countLifeTime != null)
            {
                StopCoroutine(_countLifeTime);
            }
        }

        public void OnMouseDown()
        {
            Hide();
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator CountLifeTime()
        {
            var waitForSeconds = new WaitForSeconds(_lifeTime);
            var waitForHideAnimation = new WaitForSeconds(_hideAnimationDuration);
            yield return waitForSeconds;
            _animator.PlayHideAnimation();
            yield return waitForHideAnimation;
            Hide();
        }
    }
}