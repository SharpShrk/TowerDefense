using TMPro;
using UnityEngine;

namespace Buildings
{
    [RequireComponent(typeof(CreateBuildingButtonHandler))]
    public class PriceText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _priceText;

        private CreateBuildingButtonHandler _createBuildingButtonHandler;

        private void Awake()
        {
            _createBuildingButtonHandler = GetComponent<CreateBuildingButtonHandler>();
            _priceText.text = _createBuildingButtonHandler.BuildingCost.ToString();
        }
    }
}