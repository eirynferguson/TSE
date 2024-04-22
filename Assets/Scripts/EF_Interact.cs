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
        if(GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player");
            playerScript = player.GetComponent<PlayerController>();
        }

        itemName = gameObject.name;
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveObject()
    {
        this.gameObject.SetActive(false);
    }

    void OnInteract()
    {
        if(name == "Door")
        {
            RemoveObject();
        }
    }
}
