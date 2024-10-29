using UnityEngine;

public class Blades : MonoBehaviour
{
    private float rotationSpeed = 0f;

    void Update()
    {
        // Rotate the windmill blades based on the current rotation speed
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    // Method to change the windmill's rotation speed
    public void ChangeSpeed(float newSpeed)
    {
        rotationSpeed = newSpeed;
    }
}
