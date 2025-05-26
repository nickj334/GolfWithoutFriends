using System.Collections;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float fallLevel = -5;
    GolfBallController positionScript;
    private Vector3 lastPosition;
    private GameObject ball;
    private bool hasTriggered;
    void Start()
    {
        positionScript = GetComponent<GolfBallController>();
        lastPosition = positionScript.lastPosition;
        ball = GameObject.Find("GolfBall");
        hasTriggered = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y<-5f && !hasTriggered) {
            Debug.Log("Ball has fallen");
            StartCoroutine(ResetBallWithDelay());
        }
    }

    private IEnumerator ResetBallWithDelay()
    {
        // 4 second wait so sound plays fully
        Debug.Log("Waiting for 4 seconds before resetting the ball...");
        lastPosition = ball.GetComponent<GolfBallController>().lastPosition; //Immediately get the last position (prevents setting position to ground)
        yield return new WaitForSeconds(4.0f);

        Debug.Log("4 seconds passed. Resetting the ball position to: " + lastPosition);
        // Reset the ball's position to the original starting position
        //ball.transform.position = originalPosition;
        //Debug.Log("Ball's New position: " + ball.transform.position);

        // Optionally, reset the ball's velocity to prevent sliding
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.position = lastPosition; // Use Rigidbody.position to reset the position
            ballRb.linearVelocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
        }


        // reseting trigger
        hasTriggered = false;

        // Log message or trigger any additional logic after ball reset
        Debug.Log("Ball reset to original position after 4 second delay.");
    }
}
