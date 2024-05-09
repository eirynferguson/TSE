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
        controlsShown = false;   //hides controls UI
        control.SetActive(false);  //sets UI as inactive
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void controls()
    {
        control.SetActive(true);   //when controls is clicked - show the UI
        Time.timeScale = 0f;
        controlsShown = true;  //controls shown so set to true
    }

    public void back()
    {
        control.SetActive(false);  //hides controls again and goes back to main menu
        controlsShown = false;    //controls no longer shown so set to false
    }
}
