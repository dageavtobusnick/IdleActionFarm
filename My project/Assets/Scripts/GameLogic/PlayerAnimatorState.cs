using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorState : MonoBehaviour,IPlayerAnimatorState
{
    [SerializeField]
    private string _walkName;
    [SerializeField]
    private string _attackName;

    private Animator _animator;
    private int _walkIndex;
    private int _attackIndex;

    private bool _attack;
    private bool _walk;

    public bool Attack
    {
        get => _attack;
        set
        {
            value = (!_walk) && value;
            _attack = value;
            _animator?.SetBool(_attackIndex, value);
        }
    }

    public bool Walk
    {
        get => _walk; 
        set
        {
            _walk = value;
            _animator?.SetBool(_walkIndex, value);
        }
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _walkIndex = Animator.StringToHash(_walkName);
        _attackIndex = Animator.StringToHash(_attackName);
    }
}
