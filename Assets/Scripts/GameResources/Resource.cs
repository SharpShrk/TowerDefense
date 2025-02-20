using System.Collections;
using UnityEngine;

namespace GameResources
{
    [RequireComponent(typeof(ResourceAnimator))]
    [RequireComponent(typeof(Collider))]
    public abstract class Resource : MonoBehaviour
    {
        [SerializeField] private int _volume;

        private ResourceAnimator _animator;
        private int _lifeTime = 1;
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
            if (_countLifeTime != null)
            {
                StopCoroutine(_countLifeTime);
            }
        }

        protected abstract void AddValueInWallet();

        protected abstract void ReturnToPool();
        
        private IEnumerator CountLifeTime()
        {
            var waitForSeconds = new WaitForSeconds(_lifeTime);
            var waitForHideAnimation = new WaitForSeconds(_hideAnimationDuration);
            yield return waitForSeconds;
            _animator.PlayHideAnimation();
            yield return waitForHideAnimation;
            AddValueInWallet();
            ReturnToPool();
        }
    }
}