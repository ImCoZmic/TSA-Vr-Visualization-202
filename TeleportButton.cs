using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TeleportButton : MonoBehaviour
{
    public string targetScene = "MainScene";
    private bool isTouching = false;
    private InputAction teleportAction;

    void Awake()
    {
        teleportAction = new InputAction("Teleport", InputActionType.Button, "<XRController>{RightHand}/triggerPressed");
        teleportAction.Enable();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            isTouching = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            isTouching = false;
        }
    }

    void Update()
    {
        if (isTouching && teleportAction.triggered)
        {
            SceneManager.LoadScene(targetScene);
        }
    }

    void OnDestroy()
    {
        teleportAction.Disable();
    }
}