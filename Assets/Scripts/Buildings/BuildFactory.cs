using System;
using System.Collections.Generic;
using Interfaces;
using ObjectPools;
using ResourcesFactories;
using Turrets;
using UnityEngine;

namespace Buildings
{
    public class BuildFactory : MonoBehaviour
    {
        [SerializeField] private BuildingManager _manager;
        [SerializeField] private GameObject _machineGunTurretPrefab;
        [SerializeField] private GameObject _laserGunTurretPrefab;
        [SerializeField] private GameObject _largeCaliberTurretPrefab;
        [SerializeField] private GameObject _metalFactoryPrefab;
        [SerializeField] private GameObject _energyFactoryPrefab;
        [SerializeField] private BulletPool _laserBulletPool;
        [SerializeField] private BulletPool _machinegunBulletPool;
        [SerializeField] private BulletPool _largeCaliberbulletPool;
        [SerializeField] private ResourcePool _metalPool;
        [SerializeField] private ResourcePool _energyPool;

        private Dictionary<BuildType, Func<Vector3, IBuilding>> _factoryMethods =
            new Dictionary<BuildType, Func<Vector3, IBuilding>>();

        private void Awake()
        {
            _factoryMethods[BuildType.MachineGun] = pos => CreateBuilding<Turret>(
                _machineGunTurretPrefab,
                pos,
                _machinegunBulletPool);
            _factoryMethods[BuildType.LaserGun] = pos => CreateBuilding<Turret>(
                _laserGunTurretPrefab,
                pos,
                _laserBulletPool);
            _factoryMethods[BuildType.LargeCaliber] = pos => CreateBuilding<Turret>(
                _largeCaliberTurretPrefab,
                pos,
                _largeCaliberbulletPool);
            _factoryMethods[BuildType.MetalFactory] = pos => CreateBuilding<ResourcesFactory>(
                _metalFactoryPrefab,
                pos,
                _metalPool);
            _factoryMethods[BuildType.EnergyFactory] = pos => CreateBuilding<ResourcesFactory>(
                _energyFactoryPrefab,
                pos,
                _energyPool);
        }

        public IBuilding CreateBuild(BuildType type, Vector3 position)
        {
            if (_factoryMethods.TryGetValue(type, out var factoryMethod))
            {
                return factoryMethod(position);
            }
            else
            {
                return null;
            }
        }

        private T CreateBuilding<T>(GameObject prefab, Vector3 position, object pool = null) where T : Component
        {
            var buildingObject = Instantiate(prefab, position, Quaternion.identity);
            var buildingComponent = buildingObject.GetComponent<T>();

            if (buildingComponent is IBuilding building)
            {
                _manager.RegisterBuilding(building);

                if (buildingComponent is IPoolable poolable && pool != null)
                {
                    poolable.SetPool(pool);
                }
            }

            return buildingComponent;
        }
    }
}