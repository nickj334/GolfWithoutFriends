using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    public Transform centerPoint;  // The center point around which the fireball moves
    public float radius = 5f;      // Radius of the circular path
    public float speed = 50f;       // Speed of the fireball's movement around the center
    public float angle = 0f;      // Starting angle for movement

    void Update()
    {
        // Increment the angle based on speed
        angle += speed * Time.deltaTime;  // Use deltaTime for frame rate independence
        if (angle >= 360f) angle -= 360f; // Keep angle within the range 0-360 degrees

        // Calculate the x and z position using sine and cosine for a vertical circle
        float x = centerPoint.position.x;
        float z = centerPoint.position.z + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
        float y = centerPoint.position.y + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;

        // Set the new position of the fireball (only changing position, not rotation)
        transform.position = new Vector3(x, y, z);
    }
}