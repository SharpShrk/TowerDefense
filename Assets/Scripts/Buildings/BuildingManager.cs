using UnityEngine;
using System.Collections.Generic;
using Interfaces;

namespace Buildings
{
    public class BuildingManager : MonoBehaviour
    {
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
    }
}