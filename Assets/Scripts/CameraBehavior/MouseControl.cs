using UnityEngine;

namespace CameraBehavior
{
    public class MouseControl : MonoBehaviour
    {
        private float _speed = 60f;
        private Vector3 _origin;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _origin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0))
            {
                return;
            }

            Vector3 difference = _camera.ScreenToViewportPoint(Input.mousePosition - _origin);
            Vector3 targetPosition = new Vector3(difference.y, 0, -(difference.x));
            transform.Translate(targetPosition * _speed * Time.deltaTime, Space.World);
        }
    }
}