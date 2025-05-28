



using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public Transform ramp;                // The ramp the flipper will follow
    public float flipInterval = 0.4f;     // Time interval between flips (0.4 seconds)
    public float flipSpeed = 20f;          // Speed of the flipper flipping motion
    public float maxFlipperAngle = 10f;   // Maximum flipping angle of the flipper
    public float minFlipperAngle = -30f; 
    private float currentAngle = 0f;      // Current angle of the flipper
    private float targetAngle = 0f;       // Target angle the flipper should reach
    private float flipTimer = 0f;         // Timer to track the interval for flipping
    private bool isFlipping = false;      // Whether the flipper is currently flipping
    private Quaternion startRotation;     // Store the starting rotation of the flipper

    void Start()
    {
        // Store the initial rotation (you set this in the editor for correct positioning)
        startRotation = transform.localRotation;
    }

    void Update()
    {
        // Update the flip timer
        flipTimer += Time.deltaTime;

        // If the flip timer exceeds the flip interval, trigger a flip
        if (flipTimer >= flipInterval)
        {
            // Reset the timer for the next flip
            flipTimer = 0f;

            // Set target angle for the flipper (flip up or down)
            targetAngle = isFlipping ? maxFlipperAngle : minFlipperAngle;  // Flip direction (up/down)
            isFlipping = !isFlipping;  // Toggle the flipping state
        }

        // Smoothly interpolate the current angle to the target angle (for smooth flipping)
        currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * flipSpeed);

        // Apply the ramp's angle and current flip angle to the flipper's rotation
        float rampAngle = ramp.eulerAngles.z;
        transform.localRotation = startRotation * Quaternion.Euler(0, 0, rampAngle + currentAngle);
    }
}