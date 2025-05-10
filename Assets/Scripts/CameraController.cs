using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject golfBall;
    private GameObject aimArrow;
    public Transform player;
    public Vector3 offset;          //relational offset from the origin
    private float sensitivity = 500f;
    private bool isFree = false;
    private bool isFreeButtonDown = false;
    private Vector3 freeForward = Vector3.forward * 12;
    private Vector3 freeRight = Vector3.right * 12;

    private float _yaw = 0.0f;
    private float _pitch = 0.0f;
    //Vector3 towardsPlayer3D;
    void Start()
    {
        transform.position = player.position + offset;
        golfBall = GameObject.Find("GolfBall");
        aimArrow = GameObject.Find("aimArrow");
        //towardsPlayer3D = player.position - transform.position;
        //towardsPlayer3D.y = 0.0f;
        //Vector3 towardsPlayer2D = new Vector3(towardsPlayer3D.x, 0.0f, towardsPlayer3D.z)
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseInputs();
        Quaternion TotalRotation = Quaternion.Euler(_pitch, _yaw, 0f);
        RotateCamera(TotalRotation);

    }

    void HandleMouseInputs() {
        //Mouse Drag
        Vector2 inputDelta = Vector2.zero;
        if (Input.GetMouseButton(0)) {                                                      //Check for left click
            inputDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));   //Grab change in x and y-axis
        }
        _yaw += inputDelta.x * sensitivity * Time.deltaTime;
        _pitch -= inputDelta.y * sensitivity * Time.deltaTime;

        //Bound Mode Controls
        //Right & Down Arrows (Bound)
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) {
            _yaw += 0.3f * sensitivity * Time.deltaTime;
        }
        else if (!Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)) {
            _yaw -= 0.3f * sensitivity * Time.deltaTime;
        }
        //Up & Down Arrow keys (Bound)
        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !isFree) {
            if (offset.z<-2.0f) {
                offset.y -= 1f * Time.deltaTime;
                offset.z += 6f * Time.deltaTime;
            }
        } else if (!Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow) && !isFree) {
            if (-40.0f<offset.z) {
                offset.y += 1f * Time.deltaTime;
                offset.z -= 6f * Time.deltaTime;
            }
        }

        //Free Mode Controls
        //Up & Down Arrow Keys (Free)
        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && isFree) {
            _pitch -= 0.1f * sensitivity * Time.deltaTime;
        } else if (!Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow) && isFree) {
            _pitch += 0.1f * sensitivity * Time.deltaTime;
        }
        // W & S Keys (Free)
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && isFree) {        //TODO: Disable Ball hit script when in free camera mode
            transform.position = transform.position + Quaternion.Euler(_pitch, _yaw, 0f) * freeForward * 2 *Time.deltaTime;
        } else if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && isFree) {
            transform.position = transform.position - Quaternion.Euler(_pitch, _yaw, 0f) * freeForward * 2 * Time.deltaTime;
        }
        // A & D Keys (free)
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && isFree) {
            transform.position = transform.position - Quaternion.Euler(_pitch, _yaw, 0f) * freeRight * 2 * Time.deltaTime;
        } else if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && isFree) {
            transform.position = transform.position + Quaternion.Euler(_pitch, _yaw, 0f) * freeRight * 2 * Time.deltaTime;
        }
        //Space and SHIFT Keys (free)
        if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftShift) && isFree) {
            transform.position = transform.position + Vector3.up * 12 * Time.deltaTime;
        } else if (!Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift) && isFree) {
            transform.position = transform.position - Vector3.up * 12 * Time.deltaTime;
        }

        //Go into swap modes on click
        if (Input.GetKey(KeyCode.F) && !isFreeButtonDown) {
            isFree = !isFree;
            Debug.Log(golfBall);
            golfBall.GetComponent<GolfBallController>().enabled = !isFree; //Disable Scripts using WASD & Arrow Keys (Ball Direction)
            aimArrow.SetActive(!isFree);


            isFreeButtonDown = true;

            Debug.Log(isFree);
        }

        if (!Input.GetKey(KeyCode.F)) {
            isFreeButtonDown = false;
        }

    }

    void RotateCamera(Quaternion rotation) {
        //Keep Camera bounded when bound
        if (!isFree) {
            Vector3 positionOffset = rotation * new Vector3(0,offset.y, offset.z);
            transform.position = player.position + positionOffset;
        }
        transform.rotation = rotation;

    }

    void ResetCamera() {        //TODO: Call this when the ball is reset
        _yaw = 0.0f;
        _pitch = 0.0f;
        offset = new Vector3(0.0f, 1.5f, -6.0f);
    }
}
