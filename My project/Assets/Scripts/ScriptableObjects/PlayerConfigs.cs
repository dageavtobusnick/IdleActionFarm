using UnityEngine;

[CreateAssetMenu(fileName = "Player Configs", menuName = "Game Configs/Player Configs")]
public class PlayerConfigs : ScriptableObject
{
    [Header("Player")]
    [Tooltip("Move speed of the character in m/s")]
    [SerializeField]
    private float _moveSpeed = 2.0f;

    [Tooltip("How fast the character turns to face movement direction")]
    [Range(0.0f, 0.3f)]
    [SerializeField]
    private float _rotationSmoothTime = 0.12f;

    [Tooltip("Acceleration and deceleration")]
    [SerializeField]
    private float _speedChangeRate = 10.0f;

    [SerializeField]
    private AudioClip[] _footstepAudioClips;
    [Range(0, 1)]
    [SerializeField]
    private float _footstepAudioVolume = 0.5f;
    [SerializeField]
    private int _maxStorage;

    public float MoveSpeed { get => _moveSpeed; }
    public float RotationSmoothTime { get => _rotationSmoothTime; }
    public float SpeedChangeRate { get => _speedChangeRate; }
    public float FootstepAudioVolume { get => _footstepAudioVolume; }
    public AudioClip[] FootstepAudioClips { get => _footstepAudioClips; }
    public int MaxStorage { get => _maxStorage; }
}
