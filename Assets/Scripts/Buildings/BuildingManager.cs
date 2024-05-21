using UnityEngine;
using System.Collections.Generic;
using ResourcesFactories;

public class BuildingManager : MonoBehaviour
{
    private TurretPresenter _turretPresenter;
    private List<IBuilding> _buildings = new List<IBuilding>();

    public void RegisterBuilding(IBuilding building)
    {
        if (!_buildings.Contains(building))
        {
            _buildings.Add(building);
        }
    }

    public void UnregisterBuilding(IBuilding building)
    {
        _buildings.Remove(building);
    }

    public void BuildingSelected(IBuilding building)
    {
        if (building is Turret turret)
        {
            _turretPresenter.ShowTurretInfo(turret);
        }


        if (building is ResourcesFactory factory)
        {
            //_turretPresenter.ShowTurretInfo(factory);
        }
    }
}
