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

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        myAction = GetComponent<PlayerInput>().actions.FindAction("Move");  //gets input actions for movement
        myAction.Enable();
        mainCamera = GetComponentInChildren<Camera>();
        rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; //creates constraints for movement
        Cursor.lockState = CursorLockMode.Locked;  //hide cursor
    }

    // Update is called once per frame
    void Update()
    {
        cameraRay();  //call raycast on every update
    }

    void FixedUpdate()
    {
        //Script below created movement based off of WASD movement and first person camera view
        Vector2 InputVector = myAction.ReadValue<Vector2>();
        if (InputVector == new Vector2(0.0f, 0.0f))  //if not moving/no player input
        {
            //freeze all positions - no movement
            rbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;  //freeze x and z to prevent player tipping over - only move along y axis
            transform.position += (mainCamera.transform.forward * InputVector.y * objectSpeed * Time.fixedDeltaTime) + (mainCamera.transform.right * InputVector.x * objectSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3(transform.position.x, 1.8f, transform.position.z); //change position of player whilst keeping y the same
        }

        //Script below creates rotation by using the mouse position with the player and the camera
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -60f, 100f);

        transform.rotation = Quaternion.Euler(0, xRotation, 0);  //player rotates
        mainCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);  //camera rotates with player
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
        int layerMask = 1 << LayerMask.NameToLayer("Interactable");  //finds items with the layer interactable

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));  //sets ray to the middle of screen
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);  //draws ray within scene and is not shown in the game 

        if(Physics.Raycast(ray, out RaycastHit hit, 10, layerMask)) //if raycast hits interactable layer
        {
            targetObject = GameObject.Find(hit.collider.transform.gameObject.name);  //targetobject becomes the gameobject the raycast has hit
        }
        else
        {
            targetObject = null; //else targetobject remains null
        }
    }
}
