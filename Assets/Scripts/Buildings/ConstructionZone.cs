using UnityEngine;
using System.Collections.Generic;

public class ConstructionZone : MonoBehaviour
{
    private List<BuildingPlace> _buildingPlaces = new List<BuildingPlace>();

    private void Awake()
    {
        FindAndAddAllBuildingPlaces();
    }

    private void FindAndAddAllBuildingPlaces()
    {
        BuildingPlace[] places = GetComponentsInChildren<BuildingPlace>();

        foreach (BuildingPlace place in places)
        {
            _buildingPlaces.Add(place);
        }
    }

    public void HighlightAvailablePlaces()
    {
        foreach (var place in _buildingPlaces)
        {
            if (place.IsCellFree)
            {
                place.Highlight();
            }
        }
    }

    public void ClearHighlights()
    {
        foreach (var place in _buildingPlaces)
        {
            place.ClearHighlight();
        }
    }
}
