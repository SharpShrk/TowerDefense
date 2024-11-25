using Buildings;
using UnityEngine;
using UnityEngine.UI;
using Wallets;

namespace UI
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(CreateBuildingButtonHandler))]
    public class BalanceChecker : MonoBehaviour
    {
        [SerializeField] private MetalWallet _metalWallet;
        [SerializeField] private Image _curtain;

        private CreateBuildingButtonHandler _buildButtonHandler;
        private int _buildingCost;
        private Button _buildButton;

        private void Awake()
        {
            _buildButton = GetComponent<Button>();
            _buildButtonHandler = GetComponent<CreateBuildingButtonHandler>();
            _buildingCost = _buildButtonHandler.BuildingCost;
            _metalWallet.ValueChanged += OnMetalValueChanged;
        }

        private void OnDisable()
        {
            _metalWallet.ValueChanged -= OnMetalValueChanged;
        }

        private void OnMetalValueChanged(int metalValue)
        {
            if (metalValue < _buildingCost)
            {
                _buildButton.interactable = false;
                _curtain.gameObject.SetActive(true);
            }
            else
            {
                _buildButton.interactable = true;
                _curtain.gameObject.SetActive(false);
            }
        }
    }
}