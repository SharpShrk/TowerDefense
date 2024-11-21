using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CreateBuildingButtonHandler : MonoBehaviour
{
    [SerializeField] private BuildFactory _buildFactory;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private BuildType _buildType;
    [SerializeField] private ConstructionZone _constructionZone;
    [SerializeField] private MetalWallet _wallet;
    [SerializeField] private int _buildingCostConstruction;

    private Button _buildingButton;
    private bool _waitingForPlacement = false;

    public int BuildingCost => _buildingCostConstruction;

    private bool IsTurret(BuildType buildType) =>
        buildType == BuildType.MachineGun ||
        buildType == BuildType.LaserGun ||
        buildType == BuildType.LargeCaliber;

    private bool IsResourceFactory(BuildType buildType) =>
        buildType == BuildType.EnergyFactory ||
        buildType == BuildType.MetalFactory;

    private void OnEnable()
    {
        _buildingButton = gameObject.GetComponent<Button>();
        _buildingButton.onClick.AddListener(StartPlacingBuildingOnClick);
    }

    private void OnDisable()
    {
        _buildingButton.onClick.RemoveListener(StartPlacingBuildingOnClick);
    }

    private void StartPlacingBuildingOnClick()
    {
        _waitingForPlacement = true;
        StartCoroutine(WaitForPlacementCoroutine());
    }

    private void HighlightPlaces()
    {
        if (IsTurret(_buildType))
        {
            _constructionZone.HighlightAvailableTurretPlaces();
        }
        else if (IsResourceFactory(_buildType))
        {
            _constructionZone.HighlightAvailableResourcePlaces();
        }
    }

    private bool CanPlaceBuilding(BuildingPlace buildingPlace)
    {
        if (buildingPlace.IsTurretPlace && IsTurret(_buildType))
        {
            return true;
        }
        else if (!buildingPlace.IsTurretPlace && IsResourceFactory(_buildType))
        {
            return true;
        }
        return false;
    }

    private IEnumerator WaitForPlacementCoroutine()
    {
        HighlightPlaces();

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        RaycastHit[] hits;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            BuildingPlace buildingPlace = hit.collider.GetComponent<BuildingPlace>();

            if (buildingPlace != null && buildingPlace.IsCellFree)
            {
                if (CanPlaceBuilding(buildingPlace))
                {
                    if (_wallet.SpendResource(_buildingCostConstruction))
                    {
                        _buildFactory.CreateBuild(_buildType, buildingPlace.InstallationPoint.position);
                        buildingPlace.CloseCell();
                        break;
                    }
                    
                }
            }
        }

        _constructionZone.ClearHighlights();
        _waitingForPlacement = false;
    }
}