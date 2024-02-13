using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float objectSpeed = 7;
    public float mouseSensitivity = 2.0f;
    public Camera mainCamera;

    Rigidbody rbody;
    InputAction myAction;
    Vector2 mousePosition;

    float sensX = 600;
    float sensY = 600;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        myAction = GetComponent<PlayerInput>().actions.FindAction("Move");
        myAction.Enable();
        mainCamera = GetComponentInChildren<Camera>();
        rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector2 InputVector = myAction.ReadValue<Vector2>();
        if (InputVector == new Vector2(0.0f, 0.0f))
        {
            rbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            transform.position += (mainCamera.transform.forward * InputVector.y * objectSpeed * Time.fixedDeltaTime) + (mainCamera.transform.right * InputVector.x * objectSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3(transform.position.x, 3.8f, transform.position.z);
        }

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -60f, 100f);

        transform.rotation = Quaternion.Euler(0, xRotation, 0);
        mainCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
