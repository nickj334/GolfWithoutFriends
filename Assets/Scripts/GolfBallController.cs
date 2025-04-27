using UnityEngine;
using UnityEngine.UI;

public class GolfBallController : MonoBehaviour
{
    public Transform aimPivot; // Aiming reference
    public float aimSpeed = 90f; // Degrees per second
    public float power = 0f;
    public float maxPower = 40f;
    public float powerChargeSpeed = 15f;
    public Slider powerMeter; // UI element to show power

    private Rigidbody rb;
    private bool hasShot = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (hasShot) return; // Prevent aiming after shot

        // Aiming left/right (A/D keys)
        float aimInput = Input.GetAxisRaw("Horizontal");
        aimPivot.Rotate(Vector3.up, aimInput * aimSpeed * Time.deltaTime);

        // Charging power (W/S keys)
        float powerInput = Input.GetAxisRaw("Vertical");
        power += powerInput * powerChargeSpeed * Time.deltaTime;
        power = Mathf.Clamp(power, 0, maxPower);

        // Update the power meter
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

    void Shoot()
    {
        rb.AddForce(aimPivot.forward * power, ForceMode.Impulse);
        hasShot = true;
    }

    void FixedUpdate()
    {
        if (hasShot && rb.linearVelocity.magnitude < 0.1f)
        {
            hasShot = false;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            power = 0f; // Reset power after shot
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Slightly reduce speed when hitting something
        rb.linearVelocity *= 0.8f;
    }
}
