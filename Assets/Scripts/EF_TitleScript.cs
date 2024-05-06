using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EF_TitleScript : MonoBehaviour
{
    public GameObject control;
    public static bool controlsShown = false;

    // Start is called before the first frame update
    void Start()
    {
        controlsShown = false;
        control.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void controls()
    {
        control.SetActive(true);
        Time.timeScale = 0f;
        controlsShown = true;
    }

    public void back()
    {
        control.SetActive(false);
        controlsShown = false;
    }
}
