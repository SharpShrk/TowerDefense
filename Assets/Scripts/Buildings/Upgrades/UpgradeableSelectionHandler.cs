using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Upgrades
{
    public class UpgradeableSelectionHandler : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private UpgradePresenter _upgradePresenter;        

        private void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit[] hits;
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                hits = Physics.RaycastAll(ray);

                foreach (RaycastHit hit in hits)
                {
                    if (!hit.collider.isTrigger)
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
    }
}