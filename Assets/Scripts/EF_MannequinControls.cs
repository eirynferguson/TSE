using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EF_MannequinControls : MonoBehaviour
{
    bool spotted = false;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
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
                var rotation = Quaternion.LookRotation(target.transform.position - transform.position);  //finds position of the player
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 4.0f);  //rotates the mannequin
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


    public void seen(bool ami)
    {
        spotted = ami;
    }
}
