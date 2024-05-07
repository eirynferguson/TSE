using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EF_MannequinControls : MonoBehaviour
{
    public GameObject target;
    public bool anxietyHigh = false;
    //get anxiety script

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        //get component anxiety script
        anxietyHigh = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (anxietyHigh == true)
        {
            var rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 0.5f);
        }
    }
}
