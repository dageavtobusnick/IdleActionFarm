using UnityEngine;

public class SellZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ISellTimer>(out var timer))
        {
            timer.StartTrySelling();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ISellTimer>(out var timer))
        {
            timer.StopTrySelling();
        }
    }
}
