using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobScript : MonoBehaviour
{
    public Animator camAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            camAnim.ResetTrigger("idle");  //when player is walking, set idle animation to reset and start walking animation
            camAnim.SetTrigger("walk");
        }
        else
        {
            camAnim.ResetTrigger("walk"); //when player is not walking, set walk animation to reset and start idle animation
            camAnim.SetTrigger("idle");
        }
    }
}
