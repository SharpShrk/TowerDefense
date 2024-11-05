using System.Collections.Generic;
using UnityEngine;

namespace GameResources
{
    public class ResourcePool : MonoBehaviour
    {
        [SerializeField] private Resource _resourcePrefab;
        [SerializeField] private int _initialPoolSize = 10;
        [SerializeField] private int _maxPoolSize = 50;
        [SerializeField] private GameObject _resourceContainer;
        [SerializeField] private EnergyWallet _energyWallet;
        [SerializeField] private MetalWallet _metalWallet;

        private Queue<Resource> _resourcePoolQueue;

        private void Awake()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            _resourcePoolQueue = new Queue<Resource>();

            for (int i = 0; i < _initialPoolSize; i++)
            {
                Resource resource = Instantiate(_resourcePrefab, _resourceContainer.transform);
                AssignWallet(resource);
                resource.gameObject.SetActive(false);
                _resourcePoolQueue.Enqueue(resource);
            }
        }

        public Resource GetResource()
        {
            if (_resourcePoolQueue.Count > 0)
            {
                Resource resource = _resourcePoolQueue.Dequeue();
                resource.gameObject.SetActive(true);
                return resource;
            }

            if (_resourcePoolQueue.Count + 1 <= _maxPoolSize)
            {
                Resource newResource = Instantiate(_resourcePrefab, _resourceContainer.transform);
                return newResource;
            }

            Debug.Log("Превышен максимальный размер пула ресурсов");
            return null;
        }

        public void ReturnResource(Resource resource)
        {
            if (_resourcePoolQueue.Count < _maxPoolSize)
            {
                resource.gameObject.SetActive(false);
                _resourcePoolQueue.Enqueue(resource);
            }
            else
            {
                Destroy(resource.gameObject);
                Debug.Log("Ресурс уничтожен, так как пул переполнен");
            }
        }

        private void AssignWallet(Resource resource)
        {
            if (resource is Energy energyResource)
            {
                energyResource.Initialize(_energyWallet, this); //убедиться что работает
            }
            else if(resource is Metal metalResource)
            {
                metalResource.Initialize(_metalWallet, this); //убедиться что работает
            }
        }
    }
}