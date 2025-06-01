using UnityEngine;
using System.Collections;

public class HoleTrigger : MonoBehaviour
{
    // Reference to the ball's Rigidbody
    public GameObject ball;  // Drag and drop your ball GameObject in the Inspector
    public HoleInfoUI holeInfoUI;  // Reference to UI for updating shot count
    private Vector3 originalPosition; // Store the starting position of the ball
    private GolfPuttSound golfPuttSound;  // For playing sound effects

    // Start is called before the first frame update
    void Start()
    {
        // Store the original position of the ball
        originalPosition = ball.transform.position;

        // Get the GolfPuttSound component from the ball
        golfPuttSound = ball.GetComponent<GolfPuttSound>();
    }

    // Event when an object enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the ball
        if (other.CompareTag("Player"))
        {
            // Play the cup sound
            if (golfPuttSound != null)
            {
                golfPuttSound.BallInTheCupSound();
            }

            // Start the coroutine for delayed actions
            StartCoroutine(PlayCommentAfterDelay());
            StartCoroutine(ResetBallWithDelay());
        }
    }

    private IEnumerator PlayCommentAfterDelay()
    {
        yield return new WaitForSeconds(0.75f); // Delay to finish cup sound

        if (golfPuttSound != null && golfPuttSound.BallInTheCupClips.Length > 0)
        {
            int index = Random.Range(0, golfPuttSound.BallInTheCupClips.Length);
            AudioClip selectedClip = golfPuttSound.BallInTheCupClips[index];

            golfPuttSound.audioSource.PlayOneShot(selectedClip);

            // Wait for the comment clip to finish before proceeding
            yield return new WaitForSeconds(selectedClip.length);
        }
    }

    private IEnumerator ResetBallWithDelay()
    {
        yield return new WaitForSeconds(4.0f); // Delay to allow sound to finish

        if (GameModeManager.Instance != null && GameModeManager.Instance.IsPracticeMode)
        {
            // Practice Mode: reset ball to tee and shot count
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                ballRb.position = originalPosition;
                ballRb.linearVelocity = Vector3.zero;
                ballRb.angularVelocity = Vector3.zero;
            }

            if (GameManager.Instance != null)
            {
                GameManager.Instance.holeScores[GameManager.Instance.currentHoleIndex] = 0;
            }

            if (holeInfoUI != null)
            {
                holeInfoUI.UpdateHoleInfoDisplay();
            }

            Debug.Log("Practice Mode: Ball reset to tee.");
        }
        else
        {
            // Game Mode: advance to next hole and reset shot count
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AdvanceHole();  // This method handles loading the next scene and resetting score
            }

            Debug.Log("Game Mode: Advancing to next hole.");
        }
    }
}
