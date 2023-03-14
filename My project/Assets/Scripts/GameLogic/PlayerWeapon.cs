using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]
public class PlayerWeapon : MonoBehaviour
{
    private Collider _collider;
    private MeshRenderer _meshRenderer;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _meshRenderer = GetComponent<MeshRenderer>();
        enabled = false;
    }
    private void OnEnable()
    {
        _meshRenderer.enabled = true;
    }
    public void StartAttack()
    {
        _collider.enabled = true;
    }
    public void StopAttack()
    {
        _collider.enabled = false;
    }
    private void OnDisable()
    {
        _meshRenderer.enabled = false;
    }
}
