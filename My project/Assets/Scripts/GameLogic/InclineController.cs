using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof (Rig))]
public class InclineController : MonoBehaviour, IInclineController
{
    [SerializeField]
    private float _poseWeight;
    [SerializeField]
    private float _normalWeight;

    private Rig _aimConstraint;
    private float _weight;
    private bool _needUpdate;

    private void Awake()
    {
        _aimConstraint = GetComponent<Rig>();
    }
    private void Update()
    {
        if (_needUpdate)
        {
            _needUpdate = false;
            _aimConstraint.weight = _weight;
        }
    }

    public void StartPose()
    {
        _weight = _poseWeight;
        _needUpdate = true;
    }

    public void StopPose()
    {
        _weight = _normalWeight;
        _needUpdate = true;
    }
}
