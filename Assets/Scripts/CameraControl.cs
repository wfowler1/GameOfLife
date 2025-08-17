using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float pitch;
    public float yaw;
    public Vector3 target = Vector3.zero;
    public float sensitivity = 1f;
    public float distance = 25f;
    public float movementSpeed = 30;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        distance -= Input.GetAxisRaw("Mouse ScrollWheel") * 50;
        distance = Mathf.Max(distance, 0);
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
            pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        }
        else if (Input.GetKey(KeyCode.Mouse2))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            target += transform.rotation * new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"), 0) * sensitivity;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= transform.right;
        }
        if (Input.GetKey(KeyCode.E))
        {
            movement += transform.up;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            movement -= transform.up;
        }

        movement = movement.normalized * movementSpeed * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 2 : 1);
        target += movement;

        transform.position = target;
        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.up, yaw, Space.Self);
        transform.Rotate(Vector3.right, pitch, Space.Self);

        transform.Translate(Vector3.forward * -distance);

    }
}
