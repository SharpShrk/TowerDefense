using System.Collections;
using Resources;
using UnityEngine;

namespace ResourcesFactories
{
    public abstract class ResourcesFactory : MonoBehaviour
    {
        [SerializeField] private Resource _spawningResource;
        [SerializeField] private ResourcePool _pool;
        [SerializeField] private SpawnPoint _spawnPoint;

        private float _iterationTime;
        private float _minIterationTime = 9;
        private float _maxIterationTime = 13;
        private Resource _currentResource;
        private Coroutine _createResource;
        private bool _isCreating = false;

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

        public void Init()
        {
            // сюда прокидывать нужно пул, пока пусто так как нет системы постройки 
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