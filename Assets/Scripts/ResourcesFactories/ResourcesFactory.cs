using System.Collections;
using GameResources;
using UnityEngine;
using UnityEngine.Pool;

namespace ResourcesFactories
{
    public abstract class ResourcesFactory : MonoBehaviour, IBuilding, IPoolable
    {
        [SerializeField] private Resource _spawningResource;
        [SerializeField] private SpawnPoint _spawnPoint;
        
        private ResourcePool _pool;
        private ResourcesFactoryData _data;
        private Resource _currentResource;
        private Coroutine _createResource;
        private bool _isCreating = false;

        private void OnEnable()
        {
            _data = GetComponent<ResourcesFactoryData>();
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
            yield return new WaitForSeconds(_data.Cooldown);

            while (_isCreating)
            {
                yield return new WaitForSeconds(_data.Cooldown);
                _currentResource = _pool.GetResource();
                _currentResource.transform.position = _spawnPoint.transform.position;
                _currentResource.gameObject.SetActive(true);
            }
        }
    }
}