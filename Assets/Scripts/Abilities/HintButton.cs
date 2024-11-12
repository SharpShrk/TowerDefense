using UnityEngine;
using UnityEngine.UI;

namespace Abilities
{
    [RequireComponent(typeof(Button))]
    public class HintButton : MonoBehaviour
    {
        [SerializeField] private HintPanel _hintPanel;

        private Button _hintButton;

        private void Awake()
        {
            _hintButton = GetComponent<Button>();
            _hintButton.onClick.AddListener(OnHintButtonClick);
        }

        private void OnDisable()
        {
            _hintButton.onClick.RemoveListener(OnHintButtonClick);
        }

        private void OnHintButtonClick()
        {
            Time.timeScale = 0;
            _hintPanel.gameObject.SetActive(true);
        }
    }
}