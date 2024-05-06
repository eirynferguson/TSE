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
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("Paused");

        Cursor.lockState = CursorLockMode.None;

        buttons.SetActive(true);
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Unpaused");

        Cursor.lockState = CursorLockMode.Locked;

        buttons.SetActive(false);
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void controls()
    {
        controlButton.SetActive(true);
        Time.timeScale = 0f;
        controlsShown = true;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
