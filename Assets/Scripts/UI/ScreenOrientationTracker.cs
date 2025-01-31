using UnityEngine;

namespace UI
{
    public class ScreenOrientationTracker : MonoBehaviour
    {
        [SerializeField] private float _landscapeFieldOfViewValue;
        [SerializeField] private float _portraitFieldOfViewValue;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnRectTransformDimensionsChange()
        {
            if (_camera == null)
            {
                _camera = Camera.main;
            }

            if (Screen.width > Screen.height)
            {
                _camera.fieldOfView = _landscapeFieldOfViewValue;
            }
            else
            {
                _camera.fieldOfView = _portraitFieldOfViewValue;
            }
        }
    }
}