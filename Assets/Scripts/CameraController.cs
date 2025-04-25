using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    public Vector3 offset;          //relational offset from the origin
    private float rotationDegreee = 1.0f;
    private Quaternion yRightRotation;
    private Quaternion yLeftRotation;
    private float sensitivity = 500f;

    private float _yaw = 0.0f;
    private float _pitch = 0.0f;
    //Vector3 towardsPlayer3D;
    void Start()
    {
        yRightRotation = Quaternion.AngleAxis(rotationDegreee, Vector3.up);
        yLeftRotation = Quaternion.AngleAxis(-rotationDegreee, Vector3.up);
        transform.position = player.position + offset;
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


        //Only right detected, move right
        /*if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) {
            offset = yRightRotation * offset;   //TODO: This is dependent on framerate
            //towardsPlayer3D = player.position - transform.position;
            //towardsPlayer3D.y = 0.0f;
            //towardsPlayer3D = yLeftRotation * towardsPlayer3D;
            transform.Rotate(0.0f, rotationDegreee, 0.0f);
            
        } 
        //Only left detected, move left
        else if (!Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)) {
            offset = yLeftRotation * offset;
            //towardsPlayer3D = player.position - transform.position;
            //towardsPlayer3D.y = 0.0f;
            //towardsPlayer3D = yRightRotation * towardsPlayer3D;
            transform.Rotate(0.0f, -rotationDegreee, 0.0f);
        }
        //Debug.Log(offset);
        transform.position = player.position + offset;*/
    }

    void HandleMouseInputs() {
        //Mouse Drag
        Vector2 inputDelta = Vector2.zero;
        if (Input.GetMouseButton(0)) {                                                      //Check for left click
            inputDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));   //Grab change in x and y-axis
        }
        _yaw += inputDelta.x * sensitivity * Time.deltaTime;
        _pitch -= inputDelta.y * sensitivity * Time.deltaTime;
        //Right & Down Arrows
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) {
            _yaw += 0.3f * sensitivity * Time.deltaTime;
        }
        else if (!Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)) {
            _yaw -= 0.3f * sensitivity * Time.deltaTime;
        }

        //Up & Down Keys for Rotation
        /*if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) {
            _pitch += 0.3f * sensitivity * Time.deltaTime;
        } else if (!Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)) {
            _pitch -= 0.3f * sensitivity * Time.deltaTime;
        }*/
        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) {
            if (offset.z<-2.0f) {
                offset.y -= 1f * Time.deltaTime;
                offset.z += 6f * Time.deltaTime;
            }
        } else if (!Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)) {
            if (-40.0f<offset.z) {
                offset.y += 1f * Time.deltaTime;
                offset.z -= 6f * Time.deltaTime;
            }
        }
    }

    void RotateCamera(Quaternion rotation) {
        Vector3 positionOffset = rotation * new Vector3(0,offset.y, offset.z);
        transform.position = player.position + positionOffset;
        transform.rotation = rotation;

    }
}
