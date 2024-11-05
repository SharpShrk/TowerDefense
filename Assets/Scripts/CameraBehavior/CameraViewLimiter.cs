using UnityEngine;

namespace CameraBehavior
{
    public class CameraViewLimiter : MonoBehaviour
    {
        [SerializeField] private CameraBorder _leftBorder;
        [SerializeField] private CameraBorder _rightBorder;
        [SerializeField] private CameraBorder _upperBorder;
        [SerializeField] private CameraBorder _downBorder;

        private float _zOffset = 17;
        private float _xOffset = 24;
        private Vector3 _origin;
        private Vector3 _limitedPosition;

        private void RestrictPosition()
        {
            _limitedPosition = new Vector3(Mathf.Clamp(
                transform.position.x,
                _upperBorder.transform.position.x +
                _xOffset,
                _downBorder.transform.position.x),
                transform.position.y,
                Mathf.Clamp(
                    transform.position.z,
                    _leftBorder.transform.position.z +
                    _zOffset,
                    _rightBorder.transform.position.z -
                    _zOffset));
            gameObject.transform.position = _limitedPosition;
        }

        private void Update()
        {
            RestrictPosition();
        }
    }
}