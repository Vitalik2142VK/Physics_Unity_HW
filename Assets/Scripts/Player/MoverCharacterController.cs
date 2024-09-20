using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoverPlayer : Mover
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _turnSensitinity = 10.0f;
    [SerializeField] private float _verticalMaxAngle = 89.0f;
    [SerializeField] private float _verticalMinAngle = -89.0f;

    private Transform _cameraTransform;
    private CharacterController _characterController;
    private Vector3 _verticalSpeed;
    private IInputSystem _inputSystem;
    private float _cameraAngle;

    private void OnValidate()
    {
        if (_playerCamera == null)
            throw new ArgumentNullException(nameof(_playerCamera));
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        _inputSystem = new DefaultInputSystem();

        _cameraTransform = _playerCamera.transform;
    }

    public override void Move()
    {
        if (_characterController.isGrounded)
        {
            _verticalSpeed = Vector3.down;
        }
        else
        {
            _verticalSpeed += Physics.gravity * Time.deltaTime;
        }

        Vector3 forward = Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;

        Vector3 horisontalDirection = _speed * _inputSystem.GetHorizontalAxis() * right;
        Vector3 verticalDirection = _speed * _inputSystem.GetVerticalAxis() * forward;
        Vector3 direction = horisontalDirection + verticalDirection + _verticalSpeed;

        _characterController.Move(direction * Time.deltaTime);
    }

    public override void Rotate()
    {
        _cameraAngle -= _inputSystem.GetMouseAxisY() * _turnSensitinity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
        _cameraTransform.localEulerAngles = Vector3.right * _cameraAngle;

        transform.Rotate(_turnSensitinity * _inputSystem.GetMouseAxisX() * Vector3.up);
    }
}
