using UnityEngine;
using System;
using System.Collections.Generic;
using ResourcesFactories;

public class BuildFactory : MonoBehaviour
{
    [SerializeField] private BuildingManager _manager;
    [SerializeField] private GameObject _machineGunTurretPrefab;
    [SerializeField] private GameObject _laserGunTurretPrefab;
    [SerializeField] private GameObject _largeCaliberTurretPrefab;
    [SerializeField] private GameObject _metalFactoryPrefab;
    [SerializeField] private GameObject _energyFactoryPrefab;

    private Dictionary<BuildType, Func<Vector3, IBuilding>> _factoryMethods = new Dictionary<BuildType, Func<Vector3, IBuilding>>();

    private void Awake()
    {
        _factoryMethods[BuildType.MachineGun] = pos => CreateBuilding<Turret>(_machineGunTurretPrefab, pos);
        _factoryMethods[BuildType.LaserGun] = pos => CreateBuilding<Turret>(_laserGunTurretPrefab, pos);
        _factoryMethods[BuildType.LargeCaliber] = pos => CreateBuilding<Turret>(_largeCaliberTurretPrefab, pos);
        _factoryMethods[BuildType.MetalFactory] = pos => CreateBuilding<ResourcesFactory>(_metalFactoryPrefab, pos);
        _factoryMethods[BuildType.EnergyFactory] = pos => CreateBuilding<ResourcesFactory>(_energyFactoryPrefab, pos);
    }

    public IBuilding CreateBuild(BuildType type, Vector3 position)
    {
        if (_factoryMethods.TryGetValue(type, out var factoryMethod))
        {
            return factoryMethod(position);
        }
        else
        {
            Debug.LogError($"не зарегистрирован метод для типа: {type}");
            return null;
        }
    }

    private T CreateBuilding<T>(GameObject prefab, Vector3 position) where T : Component
    {
        var buildingObject = GameObject.Instantiate(prefab, position, Quaternion.identity);
        var buildingComponent = buildingObject.GetComponent<T>();

        if (buildingComponent is IBuilding building)
        {
            _manager.RegisterBuilding(building);
        }
        else
        {
            Debug.LogError("не содержит IBuilding");
        }

        return buildingComponent;
    }
}
