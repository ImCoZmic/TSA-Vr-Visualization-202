using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class CarouselSeatLock : MonoBehaviour
{
    public Transform seatPosition; // Assign seat position
    private Transform player; // Store player reference
    private bool isSeated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            player = other.transform;
            player.position = seatPosition.position; // Snap to seat
            player.SetParent(transform); // Attach to seat
            isSeated = true;
        }
    }

    private void Update()
    {
        if (isSeated && Gamepad.current != null && Gamepad.current.rightStickButton.wasPressedThisFrame)
        {
            ExitSeat();
        }
    }

    private void ExitSeat()
    {
        if (player != null)
        {
            player.SetParent(null); // Unparent from carousel
            player.position += transform.forward * 1.5f; // Move player slightly forward
            isSeated = false;
        }
    }
}
