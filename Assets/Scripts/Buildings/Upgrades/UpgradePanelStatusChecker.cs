using UnityEngine;

namespace Upgrades
{
    public class UpgradePanelStatusChecker : MonoBehaviour
    {
        private bool _isPanelOpen = false;

        public bool CanOpenNewPanel()
        {
            return !_isPanelOpen;
        }

        public void SetPanelOpen()
        {
            _isPanelOpen = true;
        }

        public void SetPanelClosed()
        {
            _isPanelOpen = false;
        }
    }
}