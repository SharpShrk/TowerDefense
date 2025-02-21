using ObjectPools;
using System.Collections;
using UnityEngine;
using Wallets;

namespace GameResources
{
    public enum ResourceType
    {
        Metal,
        Energy
    }

    [RequireComponent(typeof(ResourceAnimator))]
    [RequireComponent(typeof(Collider))]
    public class Resource : MonoBehaviour
    {
        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private int _value;

        private ResourceAnimator _animator;
        private int _lifeTime = 1;
        private int _hideAnimationDuration = 1;
        private Coroutine _countLifeTime;
        private ResourceWallet _wallet;
        private ResourcePool _pool;

        public ResourceType ResourceType => _resourceType;

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

        public void Initialize(ResourceWallet wallet, ResourcePool pool)
        {
            _wallet = wallet;
            _pool = pool;
        }

        private void AddValueInWallet()
        {
            _wallet.AddResource(_value);
        }

        private void ReturnToPool()
        {
            _pool.ReturnResource(this);
        }
        
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