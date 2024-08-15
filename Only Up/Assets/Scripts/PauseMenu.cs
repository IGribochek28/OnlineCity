using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuPanel;
    

    void Start()
    {
        PauseMenuPanel.SetActive(false);
    }

    
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
            PauseMenuPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        } 

    }

    public void Resume()
    {
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ToModeSelector()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
