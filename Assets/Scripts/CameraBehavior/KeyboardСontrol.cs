using UnityEngine;
using UnityEngine.InputSystem;
using YG;

namespace CameraBehavior
{
    [RequireComponent(typeof(CameraViewLimiter))]
    public class KeyboardСontrol : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private CameraViewLimiter _mover;

        private PlayerInput _playerInput;
        private Vector3 _moveDirection;

        private void Awake()
        {
            if (!YandexGame.EnvironmentData.isMobile)
            {
                _playerInput = new PlayerInput();
                _playerInput.Camera.Move.performed += OnMove;
                _playerInput.Camera.Move.canceled += ResetMoveDirection;
            }
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            _moveDirection = context.action.ReadValue<Vector3>();
        }

        private void ResetMoveDirection(InputAction.CallbackContext context)
        {
            _moveDirection = Vector3.zero;
        }

        private void LateUpdate()
        {
            if (_playerInput != null)
            {
                gameObject.transform.Translate(_moveDirection * _speed * Time.deltaTime, Space.World);
            }
        }

        private void OnEnable()
        {
            if (_playerInput != null)
            {
                _playerInput.Enable();
            }
        }

        private void OnDisable()
        {
            if (_playerInput != null)
            {
                _playerInput.Disable();
            }
        }
    }
}