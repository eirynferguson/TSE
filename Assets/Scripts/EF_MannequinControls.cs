using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EF_MannequinControls : MonoBehaviour
{
    public GameObject Head;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position);
    }
}
