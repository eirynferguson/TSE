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
        if (playerScript.targetObject != null) 
        { 
            isInteract = true;
            interactable();
        }
        else if ((name == "Head") || (playerScript.targetObject == null))
        {
            isInteract = false;
            interactable();
        }
                
    }

    void interactable()
    {
        if (isInteract == true) 
        {
            playerView.color = new Color32(255, 0, 0, 255);
        }
        else if (isInteract == false)
        {
            playerView.color = new Color32(255, 255, 255, 255);
        }
    }
}
