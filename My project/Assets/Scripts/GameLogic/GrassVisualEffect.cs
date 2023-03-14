using UnityEngine;
using UnityEngine.VFX;

public class GrassVisualEffect : MonoBehaviour
{
    private VisualEffect _visualEffect;

    private void Awake()
    {
        _visualEffect = GetComponent<VisualEffect>();
    }

    public void RestartEffect()
    {
        _visualEffect.Reinit();
    }
}
