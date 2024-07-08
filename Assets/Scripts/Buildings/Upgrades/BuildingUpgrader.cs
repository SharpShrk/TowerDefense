using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgrader : MonoBehaviour, IUpgradeable
{
    private BuildingData _data;

    private void Start()
    {
        _data = GetComponent<BuildingData>();
    }

    public void Upgrade()
    {
        if (_data is TurretData turretData)
        {
            Debug.Log("Турель улучшена");

            turretData.LevelUp(turretData.BuidlingLevel + 1);
        }
        else if (_data is ResourcesFactoryData factoryData)
        {
            Debug.Log("Здание улучшено");
        }
    }
}
