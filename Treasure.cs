using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Treasure : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private TextMeshProUGUI treasureText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ParticleSystem confettiEffect; // Reference to the confetti effect

    private static int treasureCount = 0;
    private const int TOTAL_TREASURE = 5;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private Rigidbody rb; // Reference to the Rigidbody

    private void Awake()
    {
        // Get or add XR Grab Interactable component
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grabInteractable == null)
        {
            grabInteractable = gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        }

        // Get or add Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.useGravity = true; // Ensure gravity is enabled
        rb.constraints = RigidbodyConstraints.FreezeRotation; // Prevent tipping

        // Get or add AudioSource
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        Debug.Log($"Treasure initialized on {gameObject.name} with XRGrabInteractable: {grabInteractable != null}");
    }

    private void Start()
    {
        grabInteractable.selectEntered.AddListener(OnTreasureCollected);

        if (treasureText != null)
        {
            UpdateTreasureUI();
        }

        Debug.Log($"Subscribed to selectEntered on {gameObject.name}");
    }

    private void OnTreasureCollected(BaseInteractionEventArgs args)
    {
        // Cast the interactorObject to XRBaseInteractor to access the GameObject
        if (args.interactorObject is UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor interactor)
        {
            Debug.Log($"Treasure {gameObject.name} collected by {interactor.gameObject.name}");
        }
        else
        {
            Debug.Log($"Treasure {gameObject.name} collected by an unknown interactor");
        }

        // Disable physics to prevent floating
        if (rb != null)
        {
            rb.isKinematic = true; // Stop physics interactions
            rb.useGravity = false;
        }

        if (collectSound != null)
        {
            audioSource.PlayOneShot(collectSound);
        }

        treasureCount++;
        UpdateTreasureUI();

        // Check if this is the last treasure collected
        if (treasureCount == TOTAL_TREASURE)
        {
            TriggerConfetti(); // Trigger confetti effect
        }

        Invoke(nameof(DisableTreasure), 0.2f);
    }

    private void UpdateTreasureUI()
    {
        if (treasureText != null)
        {
            treasureText.text = $"Treasure Collected: {treasureCount}/{TOTAL_TREASURE}";
        }

        if (treasureCount >= TOTAL_TREASURE)
        {
            Debug.Log("All treasures collected! You win!");
        }
    }

    private void DisableTreasure()
    {
        gameObject.SetActive(false);
    }

    private void TriggerConfetti()
    {
        if (confettiEffect != null)
        {
            confettiEffect.Play(); // Play the confetti effect when the last treasure is collected
            Debug.Log("Confetti triggered!");
        }
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnTreasureCollected);
        }
    }
}
