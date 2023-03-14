using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectTriggerController : MonoBehaviour,ICollectTriggerController
{
    private Collider _collider;

    public void Lock()
    {
        _collider.enabled=false;
    }

    public void Unlock()
    {
        _collider.enabled = true;
    }
}
