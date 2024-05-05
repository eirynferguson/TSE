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
            camAnim.ResetTrigger("idle");
            camAnim.SetTrigger("walk");
        }
        else
        {
            camAnim.ResetTrigger("walk");
            camAnim.SetTrigger("idle");
        }
    }
}
