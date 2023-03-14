using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Inputs))]
public class AttackStart : MonoBehaviour,IAttackStart
{
    [Inject]
    private IPlayerAnimatorState _animatorState;
    [Inject]
    private IAttackEnd _attackEnd;
    [Inject]
    private IInclineController _inclineController;
    [Inject]
    private PlayerWeapon _playerWeapon;

    private Inputs _input;
    private bool _isAttack;

    public bool IsAttack => _isAttack;

    public event Action AttackStarted;

    private void Awake()
    {
        _input = GetComponent<Inputs>();
    }

    private void OnEnable()
    {
        _input.Attack += OnAttack;
        _attackEnd.AttackEnded += OnAttackEnded;
    }

    private void OnAttackEnded()=>_isAttack = false;

    private void OnAttack()
    {
        _animatorState.Attack = true;
        if( _animatorState.Attack&&!_isAttack)
        {
            _isAttack = true;
            _inclineController.StartPose();
            _playerWeapon.enabled=true;
        }
    }

    private void OnDisable()
    {
        _input.Attack-= OnAttack;
        _attackEnd.AttackEnded -= OnAttackEnded;
    }
}
