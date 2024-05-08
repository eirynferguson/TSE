using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class DH_ChillOutZone : MonoBehaviour
{
    bool contact;

    public AudioSource chillout;
    void OnTriggerEnter(Collider chillin)
    {
        if (chillin.name == "Player")
        {
            contact = true;
        }
    }
    private void OnTriggerExit(Collider chillin2)
    {
        if (chillin2.name == "Player")
        {
            contact = false;
        }
    }
    GameObject Chiller;
    // Start is called before the first frame update
    void Start()
    {
        contact = false;
        Chiller= GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (contact) 
        {
            Chiller.GetComponent<anxietymeter>().Listen(true);
            Chiller.GetComponent<anxietymeter>().TempAnxiety = 0;
            chillout.enabled = true;
        }
        else
        {
            Chiller.GetComponent<anxietymeter>().Listen(false);
            chillout.enabled=false;
        }
    }
}
