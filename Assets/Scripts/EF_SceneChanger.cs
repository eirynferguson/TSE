using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)  //function used to switch between scenes
    {
        SceneManager.LoadScene(sceneName);  //changes scene by the name entered in unity inspector
    }

    public void Exit()
    {
        Application.Quit();  //closes the application
        Debug.Log("Quit");
    }
}
