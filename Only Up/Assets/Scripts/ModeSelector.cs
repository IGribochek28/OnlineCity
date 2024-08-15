using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{
    
    public void OnlineGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SoloGame()
    {
        SceneManager.LoadScene(3);
    }
}
