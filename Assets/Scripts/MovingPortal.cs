using UnityEngine;

public class MovingPortal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float origin;
    float speed = .8f;
    public float radius = 15f;
    private float theta = 0f;
    void Start()
    {
        origin = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        theta += speed * Time.deltaTime;
        transform.position = new Vector3(origin + radius * Mathf.Cos(theta), transform.position.y, transform.position.z);
        if (theta>360f) {
            theta -= 360f;
        }
    }
}
