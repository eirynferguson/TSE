using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DH_TriggerA : MonoBehaviour
{
    int cooldown =0;
    public int cooldownbase;
    public double Anx;
    public double TempAnx;
    void OnTriggerEnter(Collider Checker)
    {
        if (cooldown == 0)
        {
            if (Checker.name == "Player")
            {
                GameObject SpookEm = GameObject.FindGameObjectWithTag("Player");

                SpookEm.GetComponent<anxietymeter>().Spook(Anx, TempAnx);
                cooldown = cooldownbase;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown> 0)
        {
            cooldown--;
        }
    }
}
