using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using Zenject;
#endif



[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Inputs))]

public class PlayerMovement : MonoBehaviour
{
    [Inject]
    private PlayerConfigs _playerConfigs;
    [Inject]
    private IPlayerAnimatorState _animatorState;
    [Inject]
    private MainCamera _mainCamera;

    private float _speed;
    private float _rotationVelocity;

    private CharacterController _controller;
    private Inputs _input;
    private Transform _cameraTransform;
    private Transform _transform;
    private IAttackStart _attackStart;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<Inputs>();
        _cameraTransform = _mainCamera.transform;
        _transform = transform;
        _attackStart = GetComponent<AttackStart>();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        if (_input.Move == Vector2.zero||_attackStart.IsAttack)
        {
            _animatorState.Walk = false;
            return;
        }
        _animatorState.Walk = true;
        CombineSpeed();
        var inputDirection = _input.Move.normalized;
        var targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg +
                              _cameraTransform.eulerAngles.y;
        float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref _rotationVelocity,
            _playerConfigs.RotationSmoothTime);
        _transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        _controller.Move(Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward * (_speed * Time.fixedDeltaTime));

    }


    private void CombineSpeed()
    {
        float targetSpeed = _playerConfigs.MoveSpeed;
        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;
        float speedOffset = 0.1f;
        float inputMagnitude = _input.AnalogMovement ? _input.Move.magnitude : 1f;
        if (currentHorizontalSpeed < targetSpeed - speedOffset ||
            currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                Time.fixedDeltaTime * _playerConfigs.SpeedChangeRate);

            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = targetSpeed;
        }
    }
}
