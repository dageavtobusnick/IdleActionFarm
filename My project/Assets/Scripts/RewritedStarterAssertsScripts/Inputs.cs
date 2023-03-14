using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif


#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
[RequireComponent(typeof(PlayerInput))]
#endif
public class Inputs : MonoBehaviour
{
    [Header("Character Input Values")]
    [SerializeField]
    private Vector2 _move;

    private bool _analogMovement;

    public Vector2 Move { get => _move; }
    public bool AnalogMovement { get => _analogMovement; }

    public event Action Attack;


#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput(context.ReadValue<Vector2>());
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AttackInput();
        }
    }

#endif

    public void MoveInput(Vector2 newMoveDirection)
    {
        _move = newMoveDirection;
    }

    public void AttackInput()
    {
        Attack?.Invoke();
    }
}

