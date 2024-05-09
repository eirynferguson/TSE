using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject buttons;
    public GameObject pauseUI;
    public GameObject controlButton;
    public static bool isPaused = false;
    public static bool controlsShown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        controlsShown = false;
        isPaused = false;
        ResumeGame();
        buttons.SetActive(false);
        controlButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //when escape is pressed - if game is already paused - resume game
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else    //else if the game is not paused - then call pause
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("Paused");

        Cursor.lockState = CursorLockMode.None;  //shows cursor

        buttons.SetActive(true);  //shows pause buttons
        pauseUI.SetActive(true);  //shows pause UI
        controlButton.SetActive(false);   //hides controls instructions
        Time.timeScale = 0f;
        controlsShown = false;  //controls are not shown so set to false
        isPaused = true;    //game is paused so set to true
    }

    public void ResumeGame()
    {
        Debug.Log("Unpaused");

        Cursor.lockState = CursorLockMode.Locked;  //hides cursor

        buttons.SetActive(false);  //hide pause buttons
        pauseUI.SetActive(false);  //hide pause UI
        Time.timeScale = 1f;
        isPaused = false;   //no longer paused so set to false
    }

    public void controls()
    {
        controlButton.SetActive(true);  //show controls UI
        Time.timeScale = 0f;
        controlsShown = true;  //controls shown so set to true
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");  //use scenechanger script to reload main menu scene
    }
}
