using UnityEngine;

public class Consumer : MonoBehaviour // Fixed: 'MonoBehavior' to 'MonoBehaviour'
{
    Collider _collider;

    void Start() // Fixed: 'start' to 'Start'
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    void OnTriggerEnter(Collider other) // Fixed: 'onTriggerEnter' to 'OnTriggerEnter'
    {
        Consumable consumable = other.GetComponent<Consumable>();
        if (consumable != null && !consumable.IsFinished)
        {
            consumable.Consume();
        }
    }
}