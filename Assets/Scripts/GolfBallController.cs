using UnityEngine;
using UnityEngine.UI;

public class GolfBallController : MonoBehaviour
{
    public Transform aimPivot; // Aiming reference
    public float aimSpeed = 90f; // Degrees per second
    public float power = 0f;
    public float maxPower = 60f;
    public float powerChargeSpeed = 30f;
    public Vector3 originalPosition;
    public Vector3 lastPosition;
    public Slider powerMeter; // UI element to show power
    public GameObject aimArrow; // Reference to the visual arrow
    public HoleInfoUI holeInfoUI; // score card upper right

    private Rigidbody rb;
    private bool hasShot = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        lastPosition = transform.position;  //Set last position to be starting point
    }

    void Update()
    {
        if (hasShot) return; // Prevent aiming while ball is moving

        // Aiming left/right (A/D keys)
        float aimInput = Input.GetAxisRaw("Horizontal");
        aimPivot.Rotate(Vector3.up, aimInput * aimSpeed * Time.deltaTime);

        // Charging power (W/S keys)
        float powerInput = Input.GetAxisRaw("Vertical");
        power += powerInput * powerChargeSpeed * Time.deltaTime;
        power = Mathf.Clamp(power, 0, maxPower);

        // Update the power meter UI
        if (powerMeter != null)
        {
            powerMeter.value = power / maxPower;
        }

        // Shoot with Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        // Always follow ball position
        aimPivot.position = transform.position;

        if (rb.linearVelocity.magnitude > 0.5f)
        {
            if (aimArrow != null && aimArrow.activeSelf)
            {
                aimArrow.SetActive(false); // Hide arrow whenever ball is moving
            }
        }

        if (hasShot)
        {
            if (rb.linearVelocity.magnitude < 0.5f)
            {
                Debug.Log("Last Position: " + transform.position);
                hasShot = false;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                power = 0f;
                lastPosition = transform.position;

                if (aimArrow != null)
                {
                    aimArrow.SetActive(true); // Show arrow when ball stops
                }

                ResetAimPivotRotation();
            }
        }
    }


    void Shoot()
    {
        rb.AddForce(aimPivot.forward * power, ForceMode.Impulse);
        hasShot = true;

        if (aimArrow != null)
        {
            aimArrow.SetActive(false); // Hide the arrow during movement
        }

        ResetAimPivotRotation();

        if (holeInfoUI != null)
        {
            holeInfoUI.IncrementShot();  // Increment shot after shooting
        }
    }

    void ResetAimPivotRotation()
    {
        // Flatten the aimPivot's rotation
        Vector3 flatForward = Vector3.ProjectOnPlane(aimPivot.forward, Vector3.up).normalized;
        aimPivot.rotation = Quaternion.LookRotation(flatForward, Vector3.up);
    }

    public void ResetBall() {
        rb.position = originalPosition;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        lastPosition = originalPosition;

    }

    void OnCollisionEnter(Collision collision)
    {
        // Slightly reduce speed when hitting something
        rb.linearVelocity *= 0.8f;
    }
}
