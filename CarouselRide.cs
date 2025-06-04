using UnityEngine;

public class CarouselRide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player steps on
        {
            other.transform.SetParent(transform.parent); // Attach to carousel
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Player steps off
        {
            other.transform.SetParent(null); // Detach from carousel
        }
    }
}
