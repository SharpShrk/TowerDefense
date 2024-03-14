using System.Collections.Generic;
using UnityEngine;

namespace Resources
{
    public class ResourcePool : MonoBehaviour
    {
        [SerializeField] private Resource _resource;
        [SerializeField] private int _capacity;

        private List<Resource> _pool = new List<Resource>();

        private void Awake()
        {
            for(int i = 0; i < _capacity; i++)
            {
                Resource resource = Instantiate(_resource, gameObject.transform);
                resource.gameObject.SetActive(false);
                _pool.Add(resource);
            }
        }

        public Resource GetResource()
        {
            foreach(Resource resource in _pool)
            {
                if(!resource.gameObject.activeSelf)
                    return resource;
            }

            Resource newResource = Instantiate( _resource, gameObject.transform);
            _pool.Add(newResource);
            return newResource;
        }
    }
}