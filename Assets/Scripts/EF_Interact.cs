using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public GameObject player;
    PlayerController playerScript;

    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Player") != null)  //if player gameobject is not null
        {
            player = GameObject.FindGameObjectWithTag("Player");  //find game object with the player tag 
            playerScript = player.GetComponent<PlayerController>();   //call player controller script
        }

        itemName = gameObject.name;  //name of the gameobject
        gameObject.layer = LayerMask.NameToLayer("Interactable");  //make sure layer is interactable
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveObject()
    {
        this.gameObject.SetActive(false);  //remove gameobject from scene
    }

    void OnInteract()
    {
        Debug.Log("Interact");
        if(name == "Door")
        {
            RemoveObject();  //if the object interacted with is a door - remove it. it is the only game object that needs removing
        }
        else if (name == "Door1")
        {
            RemoveObject();
        }
    }
}
