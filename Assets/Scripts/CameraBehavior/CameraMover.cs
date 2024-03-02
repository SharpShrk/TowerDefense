using UnityEngine;

namespace CameraBehavior
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private float _xPosition;
        [SerializeField] private CameraBorder _leftBorder;
        [SerializeField] private CameraBorder _rightBorder;

        private float _speed = 60f;
        private float _zOffset = 20f;
        private Vector3 _origin;
        private Vector3 _currentPosition;
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

            _currentPosition = new Vector3(
                _xPosition,
                _camera.transform.position.y,
                Mathf.Clamp(
                    _camera.transform.position.z,
                    _leftBorder.transform.position.z +
                    _zOffset,
                    _rightBorder.transform.position.z -
                    _zOffset));
            _camera.transform.position = _currentPosition;
            Vector3 difference = _camera.ScreenToViewportPoint(Input.mousePosition - _origin);
            Vector3 targetPosition = new Vector3(-(difference.y * _speed), 0, -(difference.x * _speed));
            transform.Translate(targetPosition * Time.deltaTime, Space.World);
        }
    }
}