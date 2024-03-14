using System.Collections;
using Resources;
using UnityEngine;
using UnityEngine.Pool;

namespace ResourcesFactories
{
    public abstract class ResourcesFactory : MonoBehaviour, IBuilding, IPoolable
    {
        [SerializeField] private Resource _spawningResource;
        [SerializeField] private SpawnPoint _spawnPoint;
        
        private ResourcePool _pool;
        private float _iterationTime;
        private float _minIterationTime = 9;
        private float _maxIterationTime = 13;
        private Resource _currentResource;
        private Coroutine _createResource;
        private bool _isCreating = false;

        public BuildType Type { get; protected set; }

        private void OnEnable()
        {
            _isCreating = true;
            _createResource = StartCoroutine(CreateResource());
        }

        private void OnDisable()
        {
            if (_createResource != null)
            {
                _isCreating = false;
                StopCoroutine(_createResource);
            }
        }

        public void SetPool(object pool)
        {
            _pool = pool as ResourcePool;
        }

        private IEnumerator CreateResource()
        {
            _iterationTime = Random.Range(_minIterationTime, _maxIterationTime);
            var waitForSeconds = new WaitForSeconds(_iterationTime);

            while (_isCreating)
            {
                yield return waitForSeconds;
                _currentResource = _pool.GetResource();
                _currentResource.transform.position = _spawnPoint.transform.position;
                _currentResource.gameObject.SetActive(true);
                _iterationTime = Random.Range(_minIterationTime, _maxIterationTime);
            }
        }
    }
}