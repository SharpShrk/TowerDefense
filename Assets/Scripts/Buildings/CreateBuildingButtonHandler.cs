using System.Collections;
using UnityEngine;

public class CreateBuildingButtonHandler : MonoBehaviour
{
    [SerializeField] private BuildFactory _buildFactory;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private BuildType _buildType;
    [SerializeField] private ConstructionZone _constructionZone;

    private bool _waitingForPlacement = false;

    public void StartPlacingBuilding()
    {
        _waitingForPlacement = true;
        StartCoroutine(WaitForPlacementCoroutine());
    }

    private IEnumerator WaitForPlacementCoroutine()
    {
        _constructionZone.HighlightAvailablePlaces();

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            BuildingPlace buildingPlace = hit.collider.GetComponent<BuildingPlace>();

            if (buildingPlace != null && buildingPlace.IsCellFree)
            {
                _buildFactory.CreateBuild(_buildType, buildingPlace.InstallationPoint.position);
                buildingPlace.CloseCell();
            }
        }

        _constructionZone.ClearHighlights();
        _waitingForPlacement = false;
    }
}