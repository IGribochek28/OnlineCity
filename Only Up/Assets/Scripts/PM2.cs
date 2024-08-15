using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PM2 : MonoBehaviour
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
            
        }

    }

    public void ResumeOnl()
    {
        PauseMenuPanel.SetActive(false);
       
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ToModeSelectorOnl()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGameOnl()
    {
        Application.Quit();
    }
}
