using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(IPlayerAnimatorState))]
public class AttackEnd : MonoBehaviour,IAttackEnd
{
    [Inject]
    private IInclineController _inclineController;
    [Inject]
    private PlayerWeapon _playerWeapon;

    private IPlayerAnimatorState _playerAnimatorState;

    public event Action AttackEnded;


    private void Awake()
    {
        _playerAnimatorState = GetComponent<IPlayerAnimatorState>();
    }
    public void OnAttackEnded()
    {
        _playerAnimatorState.Attack = false;
        _inclineController.StopPose();
        _playerWeapon.StopAttack();
        _playerWeapon.enabled = false;
        AttackEnded?.Invoke();
    }
}
