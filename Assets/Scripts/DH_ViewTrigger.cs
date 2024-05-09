using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DH_ViewTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider creep)
    {
        if (creep.CompareTag("Mannequin"))
        {
            creep.GetComponent<EF_MannequinControls>().seen(true);
        }
    }
    private void OnTriggerExit(Collider creep2)
    {
        if (creep2.CompareTag("Mannequin"))
        {
            creep2.GetComponent<EF_MannequinControls>().seen(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
