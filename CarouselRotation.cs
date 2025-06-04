using UnityEngine;

public class CarouselRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of rotation

    void Update()
    {
        // Apply the PingPong effect for smooth rotation
        float time = Mathf.PingPong(Time.time * rotationSpeed, 1);
        transform.Rotate(Vector3.up * time * rotationSpeed * Time.deltaTime);
    }
}