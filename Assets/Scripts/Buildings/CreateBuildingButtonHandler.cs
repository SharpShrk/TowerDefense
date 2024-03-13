using System.Collections;
using UnityEngine;

public class CreateBuildingButtonHandler : MonoBehaviour
{
    [SerializeField] private BuildFactory _buildFactory;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private BuildType _buildType;

    private bool _waitingForPlacement = false;

    public void StartPlacingBuilding()
    {
        _waitingForPlacement = true;
        StartCoroutine(WaitForPlacementCoroutine());
    }

    private IEnumerator WaitForPlacementCoroutine()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); //добавить обработку для мобильных девайсов

        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            BuildingPlace buildingPlace = hit.collider.GetComponent<BuildingPlace>();

            if (buildingPlace != null)
            {
                _buildFactory.CreateBuild(_buildType, buildingPlace.InstallationPoint.position);
            }
        }

        _waitingForPlacement = false;
    }
}