using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportOnPickup : MonoBehaviour
{
    public Transform teleportLocation; // Set this in the Inspector
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(TeleportPlayer);
        }
    }

    void TeleportPlayer(SelectEnterEventArgs args)
    {
        GameObject player = GameObject.FindWithTag("Player"); // Make sure your XR Rig has the "Player" tag
        if (player != null && teleportLocation != null)
        {
            player.transform.position = teleportLocation.position;
        }
    }
}
