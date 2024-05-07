using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EF_CursorLable : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;
    PlayerController playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
        mainCamera = playerScript.mainCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.targetObject != null)
        {
            GetComponent<TMPro.TextMeshProUGUI>().text = playerScript.targetObject.name;
        }
        else
        {
            GetComponent<TMPro.TextMeshProUGUI>().text = null;
        }

        transform.position = playerScript.GetMousePosition();  //find mouse location
    }
}
