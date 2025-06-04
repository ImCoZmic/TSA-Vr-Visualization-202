using UnityEngine;

public class TeleportToFloor : MonoBehaviour
{
    public Transform xrRig; // Your XR Rig (player)
    public Vector3 targetPosition; // Where to teleport (set in Inspector)
    private bool isPlayerOnPlatform = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }

    void Update()
    {
        if (isPlayerOnPlatform && Input.GetKeyDown(KeyCode.JoystickButton0)) // Trigger press
        {
            xrRig.position = targetPosition;
        }
    }
}