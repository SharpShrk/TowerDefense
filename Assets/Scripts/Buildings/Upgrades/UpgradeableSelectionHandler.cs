using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeableSelectionHandler : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private UpgradePresenter _upgradePresenter;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var upgradeableComponent = hit.collider.GetComponent<IUpgradeable>();

                if (upgradeableComponent != null)
                {
                    _upgradePresenter.OnBuildingSelected(hit.collider.gameObject);
                }
            }
        }
    }
}