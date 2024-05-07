using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EF_MannequinControls : MonoBehaviour
{
    public GameObject player;
    public GameObject head;
    PlayerController playerScript;
    public string itemName;
    //public bool anxietyHigh = false;
    //get anxiety script

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player");
            playerScript = player.GetComponent<PlayerController>();
        }

        itemName = gameObject.name;
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        //get component anxiety script
        //anxietyHigh = false;
    }

    // Update is called once per frame
    void Update()
    {
        mannequinLook();
    }

    void staredAt()
    {
        Debug.Log("Mannequin");
        if (itemName == "Mannequin")
        {
            transform.rotation = Quaternion.LookRotation(head.transform.forward);
        }
    }

    void mannequinLook()
    {
        var rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 0.5f);
    }
}
