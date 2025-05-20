using UnityEngine;

public class RoamingBull : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 origin;
    Vector3 startingOffset;
    private float theta = -90f;
    private float x;
    public float y = 7f;
    private float z;
    void Start()
    {
        origin = GameObject.Find("BullRing").transform.position;
        startingOffset = origin - new Vector3(0f,0f,-30f);
        transform.position = origin + startingOffset;
    }

    // Update is called once per frame
    void Update()
    {
        theta += 0.3f * Time.deltaTime; //growing 3 degrees a second
        x = 55 * Mathf.Cos(theta);
        z = 30 * Mathf.Sin(theta);
        transform.position = origin + new Vector3(x,y,z);
        transform.rotation = Quaternion.Euler(-90f, (theta * -180f/Mathf.PI), 0f);
        if (theta>360f) {
            theta -= 360f;
        }
    }
}
