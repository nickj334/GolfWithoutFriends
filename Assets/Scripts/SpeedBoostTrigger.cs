using UnityEngine;
using System.Collections;

public class SpeedBoostTrigger : MonoBehaviour
{
    public float speedBoostMultiplier = 2.5f;  // The multiplier for the speed boost
    public float boostDuration = 3f;  // Duration for which the speed boost will last

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the ball
        if (other.CompareTag("Player"))  // Make sure the ball has the "Ball" tag
        {
            // Get the Rigidbody of the ball
            Rigidbody ballRb = other.GetComponent<Rigidbody>();

            if (ballRb != null)
            {
                // Temporarily increase the ball's speed
                ballRb.linearVelocity *= speedBoostMultiplier;  // Increase the velocity by the multiplier
                Debug.Log("Speed Boost Activated!");

                // Optionally, reset the speed after a duration using a coroutine
                StartCoroutine(ResetSpeedAfterDuration(ballRb));
            }
        }
    }

    // Coroutine to reset speed after the boost duration
    private IEnumerator ResetSpeedAfterDuration(Rigidbody ballRb)
    {
        // Wait for the specified boost duration
        yield return new WaitForSeconds(boostDuration);

        // Reset the ball's speed back to its original velocity
        ballRb.linearVelocity /= speedBoostMultiplier;
    }
}
