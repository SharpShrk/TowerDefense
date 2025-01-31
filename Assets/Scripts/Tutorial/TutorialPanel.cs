using UnityEngine;
using UnityEngine.UI;

namespace Tutorial
{
    public class TutorialPanel : MonoBehaviour
    {
        private void Start()
        {
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            Time.timeScale = 1.0f;
        }
    }
}