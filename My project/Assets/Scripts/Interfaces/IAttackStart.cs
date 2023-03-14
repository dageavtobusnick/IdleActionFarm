using System;

internal interface IAttackStart
{
   public event Action AttackStarted;
   public bool IsAttack { get; }
}
