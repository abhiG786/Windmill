using UnityEngine;

public class LeverControl : MonoBehaviour
{
    public Transform lever; // The red lever object
    public Blades windmillBlades; // Reference to the windmill blades
    private bool isPlayerNearLever = false; // To track if the player is near the lever
    private int speedMode = 0; // 0: Off, 1: Low, 2: Medium, 3: High
    public float leverRotationAngle = 90f; // The rotation angle for the lever (90 degrees)
    public float[] windmillSpeeds = { 0f, 50f, 100f, 200f }; // Windmill speeds for each mode

    void Update()
    {
        if (isPlayerNearLever && Input.GetKeyDown(KeyCode.Space))
        {
            ChangeSpeed();
        }
    }

    private void ChangeSpeed()
    {
        // Rotate the lever by 90 degrees
        lever.Rotate(Vector3.forward, leverRotationAngle);

        // Update the speed mode (cycles through 4 modes)
        speedMode = (speedMode + 1) % windmillSpeeds.Length;

        // Set the windmill's speed based on the new mode
        windmillBlades.ChangeSpeed(windmillSpeeds[speedMode]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearLever = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearLever = false;
        }
    }
}
