using TMPro;
using UnityEngine;

namespace Ui
{
    [RequireComponent(typeof(TMP_Text))]
    public class CurrentScoreView : MonoBehaviour
    {
        private const string AllScore = "AllScore";

        private TMP_Text _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<TMP_Text>();
            _scoreText.text = PlayerPrefs.GetInt(AllScore).ToString();
        }
    }
}