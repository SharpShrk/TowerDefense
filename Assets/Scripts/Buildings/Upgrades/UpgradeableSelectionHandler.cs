using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Buildings.Upgrades
{
    public class UpgradeableSelectionHandler : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private UpgradePresenter _upgradePresenter;

        private void Update()
        {
            if (!EventSystem.current.IsPointerOverGameObject() &&
                Input.GetMouseButtonDown(0))
            {
                RaycastHit[] hits;
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                hits = Physics.RaycastAll(ray);

                foreach (RaycastHit hit in hits)
                {
                    if (!hit.collider.isTrigger &&
                        hit.collider.TryGetComponent<IUpgradeable>(out var upgradeableComponent))
                    {
                        _upgradePresenter.OnBuildingSelected(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}