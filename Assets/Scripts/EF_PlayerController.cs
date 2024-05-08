using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float objectSpeed = 7;
    public float mouseSensitivity = 2.0f;
    public Camera mainCamera;

    GameObject targetObject;
    Rigidbody rbody;
    InputAction myAction;
    Vector2 mousePosition;

    float sensX = 600;
    float sensY = 600;
    float xRotation;
    float yRotation;

    bool anxiety = true;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        myAction = GetComponent<PlayerInput>().actions.FindAction("Move");
        myAction.Enable();
        mainCamera = GetComponentInChildren<Camera>();
        rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        cameraRay();
        checkPoint();
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
            transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
        }

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -60f, 100f);

        transform.rotation = Quaternion.Euler(0, xRotation, 0);
        mainCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    public Vector2 GetMousePosition()
    {
        return mousePosition;
    }

    public void OnMouse(InputValue mousePos)
    {
        mousePosition = mousePos.Get<Vector2>();
    }

    public GameObject getTargetObject()
    {
        return targetObject;
    }

    public void OnClickItem()
    {
        if (targetObject != null) 
        { 
            if (targetObject.name.Contains("Door"))
            {
                targetObject.SendMessage("OnInteract");
            }
        }

        Debug.Log("Item Clicked");
    }

    void cameraRay()  //item interaction
    {
        int numRay = 20;
        float x = -5;

        for (int i = 0; i < numRay; i++) 
        {
            // layerMask = 1 << LayerMask.NameToLayer("environment");
            Ray rays = mainCamera.ViewportPointToRay(new Vector3(x, 0.5f, 0));
            Debug.DrawRay(rays.origin, rays.direction * 10, Color.red);
            x = x + 0.5f;
        }

        int layerMask = 1 << LayerMask.NameToLayer("Interactable");

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));  //middle of screen
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

        if(Physics.Raycast(ray, out RaycastHit hit, 10, layerMask))
        {
            targetObject = GameObject.Find(hit.collider.transform.gameObject.name);
        }
        else
        {
            targetObject = null;
        }
    }

    void checkPoint()
    {
        if (anxiety == true)
        {
            transform.position = new Vector3(8, 0.5f, 8);
            anxiety = false;
        }
    }
}
