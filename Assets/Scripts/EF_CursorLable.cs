using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EF_CursorLable : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    public Image playerView;
    bool isInteract;

    PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
        mainCamera = playerScript.mainCamera;
        playerView = playerView.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.targetObject != null)  //if the target object is not null
        { 
            isInteract = true; //set interactable as true
            interactable();   //call interactable function
        }
        else
        {
            isInteract = false;  //else keep interactable as false
            interactable();
        }
                
    }

    void interactable()
    {
        if (isInteract == true) 
        {
            playerView.color = new Color32(255, 0, 0, 255);  //if object is interactable, change colour of 'crosshair' to red
        }
        else if (isInteract == false)
        {
            playerView.color = new Color32(255, 255, 255, 255);  //if object is not interactable, keep colour as white
        }
    }
}
