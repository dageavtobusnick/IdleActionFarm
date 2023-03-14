using UnityEngine;
using Zenject;

public class AttackContinue : MonoBehaviour
{
    [Inject]
    private PlayerWeapon _playerWeapon;

    public void OnAttackContinue()
    {
        _playerWeapon.StartAttack();
    }

}
