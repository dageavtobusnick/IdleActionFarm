using UnityEngine;

[CreateAssetMenu(fileName = "Game Configs", menuName = "Game Configs/Game Configs")]
public class GameConfigs : ScriptableObject
{
    [SerializeField]
    private float _grassDeatroyTime;
    [SerializeField]
    private float _grassGrownTime;
    [SerializeField]
    private float _grassMoveToTargetTime;
    [SerializeField]
    private float _timeBetweenSelling;
    [SerializeField]
    private float _moneyCollectedShakeTime;
    [SerializeField]
    private float _moneyMovingTime;
    [SerializeField]
    private int _grassCost;
    [SerializeField]
    private float _shakeStrength;

    public float GrassDeatroyTime { get => _grassDeatroyTime; }
    public float GrassGrownTime { get => _grassGrownTime; }
    public float GrassMoveToTargetTime { get => _grassMoveToTargetTime; }
    public float TimeBetweenSelling { get => _timeBetweenSelling; }
    public float MoneyCollectedShakeTime { get => _moneyCollectedShakeTime; }
    public float MoneyMovingTime { get => _moneyMovingTime;}
    public int GrassCost { get => _grassCost; }
    public float ShakeStrength { get => _shakeStrength;}
}
