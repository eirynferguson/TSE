using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EF_MannequinControls : MonoBehaviour
{
    //public GameObject Head;
    public GameObject target;
    bool spotted;

    public void seen(bool ami)
    {
        spotted = ami;
    }


    // Start is called before the first frame update
    void Start()
    {
        spotted = false;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //modified to only look at the player when the player is paranoid
        bool PlayerPanic = target.GetComponent<anxietymeter>().Paranoid;

        if (PlayerPanic)
        {
            if (!spotted)
            {
                var rotation = Quaternion.LookRotation(target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 4.0f);
            }
            else
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        else
        {
            //resets if not paranoid
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

}
