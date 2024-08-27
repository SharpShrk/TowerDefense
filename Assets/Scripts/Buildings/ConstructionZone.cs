using UnityEngine;
using System.Collections.Generic;

public class ConstructionZone : MonoBehaviour
{
    private List<BuildingPlace> _turretPlaces = new List<BuildingPlace>();
    private List<BuildingPlace> _resourcePlaces = new List<BuildingPlace>();

    private void Awake()
    {
        FindAndAddAllBuildingPlaces();
    }

    private void FindAndAddAllBuildingPlaces()
    {
        BuildingPlace[] places = GetComponentsInChildren<BuildingPlace>();

        foreach (BuildingPlace place in places)
        {
            if(place.IsTurretPlace == true)
            {
                _turretPlaces.Add(place);
            }
            else
            {
                _resourcePlaces.Add(place);
            }
        }
    }

    public void HighlightAvailableTurretPlaces()
    {
        foreach (var place in _turretPlaces)
        {
            if (place.IsCellFree)
            {
                place.Highlight();
            }
        }
    }

    public void HighlightAvailableResourcePlaces()
    {
        foreach (var place in _resourcePlaces)
        {
            if (place.IsCellFree)
            {
                place.Highlight();
            }
        }
    }

    public void ClearHighlights()
    {
        foreach (var place in _turretPlaces)
        {
            place.ClearHighlight();
        }

        foreach (var place in _resourcePlaces)
        {
            place.ClearHighlight();
        }
    }
}
